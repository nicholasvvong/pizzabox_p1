using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Repository
{
    public class OrderRepository
    {
        private readonly OrderContext context;

        public OrderRepository(OrderContext c)
        {
            context = c;
        }

        /// <summary>
        /// Adds a new order to the database
        /// </summary>
        /// <param name="newOrder">New Order</param>        
        public void AddOrder(Order newOrder)
        {
            context.Add<Order>(newOrder);
            context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all of the customer's orders from database
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns></returns>
        public List<Order> GetCustomerOrders(Guid id)
        {
            List<Order> newOrderHistory = new List<Order>();
            var orderhistory = context.Orders.Where(n => Guid.Equals(n.Cust,id)).OrderBy(d => d.OrderTime);
            newOrderHistory = orderhistory.ToList();

            return newOrderHistory;
        }

        /// <summary>
        /// Retrieves all the orders from a store from database
        /// </summary>
        /// <param name="id">Store iD</param>
        /// <returns></returns>
        public List<Order> GetStoreOrders(Guid id)
        {
            List<Order> newOrderHistory = new List<Order>();
            var orderhistory = context.Orders.Where(n => Guid.Equals(n.Store, id)).OrderBy(d => d.OrderTime);
            newOrderHistory = orderhistory.ToList();

            return newOrderHistory;
        }
    }
}