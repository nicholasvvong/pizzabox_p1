using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Repository;

namespace PizzaBox.Logic
{
    public class OrderLogic
    {
        private readonly OrderRepository orderRepo;
        private readonly StoreRepository storeRepo;
        private readonly Mapper mapper = new Mapper();
        public OrderLogic(OrderRepository r, StoreRepository sr)
        {
            orderRepo = r;
            storeRepo = sr;
        }
        /// <summary>
        /// Creates the order and adds it to the database. Mapped from raworder from clientside
        /// </summary>
        /// <param name="obj">RawOrder object from clientside.</param>
        /// <returns></returns>
        public Order CreateOrder(RawOrder obj)
        {
            Order newOrder = mapper.BaseOrderMapper(obj);
            List<Crust> storeCrust = storeRepo.GetCrusts(obj.StoreID);
            List<Size> storeSize = storeRepo.GetSizes(obj.StoreID);
            List<Topping> storeToppings = storeRepo.GetToppings(obj.StoreID);
            //mapper.PizzaMapper(newOrder, obj, storeCrust, storeSize, storeToppings);
            storeRepo.UpdateInventory(obj.StoreID, obj.PizzaList);
            orderRepo.AddOrder(newOrder);
            return newOrder;
        }

        /// <summary>
        /// Gets the order history of the customer based off his Guid from database.
        /// Returns a raworderhistory for the client to be read/parsed
        /// </summary>
        /// <param name="id">Customer's guid</param>
        /// <returns></returns>
        public RawOrderHistory GetOrderHistory(Guid id)
        {
            RawOrderHistory OrderHistory = new RawOrderHistory();
            List<Order> dbOrderHistory = orderRepo.GetOrders(id);
            List<string> storeNames = new List<string>();

            OrderHistory.jsonPizzaOrders = new List<string>();
            OrderHistory.StoreName = new List<string>();
            OrderHistory.Totals = new List<decimal>();
            OrderHistory.OrderTimes = new List<DateTime>();
            foreach(Order stID in dbOrderHistory)
            {
                OrderHistory.StoreName.Add(storeRepo.GetName(stID.Store));
                OrderHistory.Totals.Add(stID.CurTotal);
                OrderHistory.OrderTimes.Add(stID.OrderTime);
                OrderHistory.jsonPizzaOrders.Add(stID.JSONPizzaOrder);
            }

            return OrderHistory;
        }
    }

}