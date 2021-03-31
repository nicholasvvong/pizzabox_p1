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

        public byte[] PasswordHash(string password, byte[] salt)
        {
            using HMACSHA512 hmac = new HMACSHA512(key: salt);

            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hashedPassword;
        }

        public Order BaseOrderMapper(RawOrder obj)
        {
            Order newOrder = new Order();
            newOrder.Cust = obj.CustomerID;
            newOrder.Store = obj.StoreID;
            newOrder.CurTotal = obj.Total;
            newOrder.JSONPizzaOrder = JsonSerializer.Serialize<List<RawPizza>>(obj.PizzaList);
            return newOrder;
        }

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
    }
}