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

        public void AddOrder(Order newOrder)
        {
            context.Add<Order>(newOrder);
            context.SaveChanges();
        }

        public List<Order> GetOrders(Guid id)
        {
            List<Order> newOrderHistory = new List<Order>();
            var orderhistory = context.Orders.Where(n => Guid.Equals(n.Cust,id)).OrderBy(d => d.OrderTime);
            newOrderHistory = orderhistory.ToList();

            return newOrderHistory;
        }
    }
}