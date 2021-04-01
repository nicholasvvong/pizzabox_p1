using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Logic
{
    public class Mapper
    {
        /// <summary>
        /// Maps a RawCustomer to Customer(javascript -> database)
        /// Hashes the inputted password and stores the hash and salt
        /// </summary>
        /// <param name="obj">RawCustomer</param>
        /// <returns></returns>
        public Customer CustomerMapper(RawCustomer obj)
        {
            using (var hmac = new HMACSHA512())
            {
                Customer newCustomer = new Customer();
                newCustomer.Fname = obj.Fname;
                newCustomer.Lname = obj.Lname;
                newCustomer.Email = obj.Email.ToLower();
                newCustomer.LastStore = Guid.Empty;
                newCustomer.StoreManger = Guid.Empty;

                newCustomer.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(obj.Password));//this returns a byte[] representing the password
                newCustomer.PasswordSalt = hmac.Key;     // this assigns the randomly generated Key (comes with the HMAC instance) to the salt variable of the user instance,

                return newCustomer;
            }
        }

        /// <summary>
        /// Rehashes a password given a salt
        /// </summary>
        /// <param name="password">User input password</param>
        /// <param name="salt">account's salt</param>
        /// <returns></returns>
        public byte[] PasswordHash(string password, byte[] salt)
        {
            using HMACSHA512 hmac = new HMACSHA512(key: salt);

            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hashedPassword;
        }

        /// <summary>
        /// Map from RawOrder to Order(javascript -> database)
        /// </summary>
        /// <param name="obj">RawOrder</param>
        /// <returns></returns>
        public Order RawToBaseOrderMapper(RawOrder obj)
        {
            Order newOrder = new Order();
            newOrder.Cust = obj.CustomerID;
            newOrder.Store = obj.StoreID;
            newOrder.CurTotal = obj.Total;
            newOrder.JSONPizzaOrder = JsonSerializer.Serialize<List<RawPizza>>(obj.PizzaList);
            return newOrder;
        }

        /// <summary>
        /// Map from Order to RawOrder(database -> javascript)
        /// DOES NOT map the name. Need to do separately, depending on if customer or store history
        /// </summary>
        /// <param name="obj">List of Orders</param>
        /// <returns></returns>
        public RawOrderHistory BaseToRawOrderMapper(List<Order> obj)
        {
            RawOrderHistory newHistory = new RawOrderHistory();
            newHistory.jsonPizzaOrders = new List<string>();
            newHistory.StoreName = new List<string>();
            newHistory.Totals = new List<decimal>();
            newHistory.OrderTimes = new List<DateTime>();
            foreach(Order stID in obj)
            {
                newHistory.Totals.Add(stID.CurTotal);
                newHistory.OrderTimes.Add(stID.OrderTime);
                newHistory.jsonPizzaOrders.Add(stID.JSONPizzaOrder);
            }
            return newHistory;
        }

        /// <summary>
        /// CURRENTLY NOT USED
        /// Maps all the RawPizzas from RawOrder to BasicPizzas in Order
        /// Goes through all size/crust/toppings and creates an appropriate basic pizza
        /// </summary>
        /// <param name="newOrder">Order containing List of BasicPizzas</param>
        /// <param name="obj">Order containing List of RawPizzas</param>
        /// <param name="storeCrust">List of store's crusts</param>
        /// <param name="storeSize">List of store's sizes</param>
        /// <param name="storeToppings">List of store's toppings</param>
        public void PizzaMapper(Order newOrder, RawOrder obj, List<Crust> storeCrust, List<Size> storeSize, List<Topping> storeToppings)
        {
            foreach(RawPizza rp in obj.PizzaList)
            {
                BasicPizza bp = new BasicPizza();
                bp.Type = rp.Name;
                bp.PizzaPrice = rp.Price;
                foreach(Crust c in storeCrust)
                {
                    if(c.PizzaType.Name == rp.Crust)
                    {
                        bp.Crust = c;
                        break;
                    }
                }
                foreach(Size s in storeSize)
                {
                    if(s.PizzaType.Name == rp.Size)
                    {
                        bp.Size = s;
                        break;
                    }
                }
                foreach(string rpt in rp.Toppings)
                {
                    foreach(Topping t in storeToppings)
                    {
                        if(t.PizzaType.Name == rpt)
                        {
                            bp.Toppings.Add(t);
                            break;
                        }
                    }
                }
                newOrder.Pizzas.Add(bp);
            }
        }

        /// <summary>
        /// Maps a RawComp from user to Topping class object
        /// </summary>
        /// <param name="pComp">BasePizzaComponent</param>
        /// <param name="obj">RawComp</param>
        /// <param name="curStore">Store to add to</param>
        /// <returns>New Topping Object</returns>
        internal Topping CompToTopping(APizzaComponent pComp, RawNewComp obj, AStore curStore)
        {
            Topping newTopping = new Topping(curStore, obj.Price, 0, pComp);

            return newTopping;
        }

        /// <summary>
        /// Maps a RawPizza from user to BasicPizza
        /// </summary>
        /// <param name="obj">RawPizza from user</param>
        /// <param name="newCrust">Crust obj for BasicPizza</param>
        /// <param name="toppings">List of Topping objects</param>
        /// <returns></returns>
        internal BasicPizza RawToBasicPizzaMapper(RawNewPizza obj, Crust newCrust, List<Topping> toppings)
        {
            BasicPizza newPizza = new BasicPizza();
            newPizza.Type = obj.Name;
            newPizza.Crust = newCrust;
            newPizza.Toppings = toppings;
            return newPizza;
        }

        /// <summary>
        /// Maps a RawComp to a Crust object
        /// </summary>
        /// <param name="pComp">BasePizzaComponent</param>
        /// <param name="obj">New RawComp</param>
        /// <param name="curStore">AStore to add to</param>
        /// <returns></returns>
        internal Crust CompToCrust(APizzaComponent pComp, RawNewComp obj, AStore curStore)
        {
            Crust newCrust = new Crust(curStore, obj.Price, 0, pComp);

            return newCrust;
        }

        /// <summary>
        /// Maps RawComp to new Size object
        /// </summary>
        /// <param name="pComp">Base APizzaComponent</param>
        /// <param name="obj">New RawComp</param>
        /// <param name="curStore">AStore to add to</param>
        /// <returns></returns>
        internal Size CompToSize(APizzaComponent pComp, RawNewComp obj, AStore curStore)
        {
            Size newSize = new Size(curStore, obj.Price, 0, pComp);

            return newSize;
        }

        /// <summary>
        /// Maps an itemType to a new APizzComponent object
        /// </summary>
        /// <param name="compName">Name of new component</param>
        /// <param name="baseType">Base ItemType</param>
        /// <returns></returns>
        public APizzaComponent ItemToCompMapper(string compName, ItemType baseType)
        {
            APizzaComponent newComp = new APizzaComponent(compName, baseType);

            return newComp;
        }
    }
}