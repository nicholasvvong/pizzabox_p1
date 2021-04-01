using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Logic.Interfaces;
using PizzaBox.Repository;

namespace PizzaBox.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly OrderRepository orderRepo;
        private readonly StoreRepository storeRepo;
        private readonly CustomerRepository custRepo;
        private readonly Mapper mapper = new Mapper();
        public OrderLogic(OrderRepository r, StoreRepository sr, CustomerRepository cr)
        {
            orderRepo = r;
            storeRepo = sr;
            custRepo = cr;
        }
        
        public Order CreateOrder(RawOrder obj)
        {
            Order newOrder = mapper.RawToBaseOrderMapper(obj);
            List<Crust> storeCrust = storeRepo.GetCrusts(obj.StoreID);
            List<Size> storeSize = storeRepo.GetSizes(obj.StoreID);
            List<Topping> storeToppings = storeRepo.GetToppings(obj.StoreID);
            //mapper.PizzaMapper(newOrder, obj, storeCrust, storeSize, storeToppings);
            storeRepo.UpdateInventory(obj.StoreID, obj.PizzaList);
            custRepo.UpdateLastStore(obj);
            orderRepo.AddOrder(newOrder);
            return newOrder;
        }

        public RawOrderHistory GetCustomerOrderHistory(Guid id)
        {
            List<Order> dbOrderHistory = orderRepo.GetCustomerOrders(id);

            RawOrderHistory OrderHistory = mapper.BaseToRawOrderMapper(dbOrderHistory);
            foreach(Order stID in dbOrderHistory)
            {
                OrderHistory.StoreName.Add(storeRepo.GetName(stID.Store));
            }

            return OrderHistory;
        }
 
        public RawOrderHistory GetStoreOrderHistory(Guid id)
        {
            List<Order> dbOrderHistory = orderRepo.GetStoreOrders(id);

            RawOrderHistory OrderHistory = mapper.BaseToRawOrderMapper(dbOrderHistory);
            foreach(Order stID in dbOrderHistory)
            {
                var curCust = custRepo.GetCustomerByID(stID.Cust);
                if(curCust is null) {
                    return null;
                }
                OrderHistory.StoreName.Add(curCust.Fname + " " + curCust.Lname);
            }

            return OrderHistory;
        }
    }

}