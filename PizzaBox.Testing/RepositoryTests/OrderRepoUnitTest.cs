using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Repository;
using Xunit;

namespace PizzaBox.Testing
{
    public class OrderRepoUnitTest
    {
        [Fact]
        public void Test_AddOrder()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: "TestDb4")
            .Options;
            
            Order testOrder = new Order();
            testOrder.JSONPizzaOrder = "teststring";
            using(var context = new OrderContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

            }

            using(var context = new OrderContext(options))
            {
                OrderRepository orderRepo = new OrderRepository(context);

                orderRepo.AddOrder(testOrder);

                Order getOrder = context.Orders.SingleOrDefault(n => Guid.Equals(n.OrderID, testOrder.OrderID));

                Assert.Equal(testOrder.JSONPizzaOrder, getOrder.JSONPizzaOrder);
            }   
        }
    
        [Fact]
        public void Test_GetCustomerOrders()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: "TestDb5")
            .Options;
            
            Customer cust = new Customer();
            Order testOrder = new Order();
            testOrder.Cust = cust.CustomerID;
            testOrder.JSONPizzaOrder = "teststring";
            using(var context = new OrderContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Add<Order>(testOrder);
                context.SaveChanges();
            }

            using(var context = new OrderContext(options))
            {
                OrderRepository orderRepo = new OrderRepository(context);

                List<Order> getOrders = orderRepo.GetCustomerOrders(cust.CustomerID);

                Assert.Equal(testOrder.JSONPizzaOrder, getOrders[0].JSONPizzaOrder);
            }   
        }
    
        [Fact]
        public void Test_GetStoreOrders()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: "TestDb6")
            .Options;
            
            AStore store = new AStore();
            Order testOrder = new Order();
            testOrder.Store = store.StoreID;
            testOrder.JSONPizzaOrder = "teststring";
            using(var context = new OrderContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Add<Order>(testOrder);
                context.SaveChanges();
            }

            using(var context = new OrderContext(options))
            {
                OrderRepository orderRepo = new OrderRepository(context);

                List<Order> getOrders = orderRepo.GetStoreOrders(store.StoreID);

                Assert.Equal(testOrder.JSONPizzaOrder, getOrders[0].JSONPizzaOrder);
            }
        }
    }
}
