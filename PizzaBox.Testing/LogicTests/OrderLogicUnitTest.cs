using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Logic;
using PizzaBox.Repository;
using Xunit;

namespace PizzaBox.Testing
{
    public class OrderLogicUnitTest
    {
        [Fact]
        public void Test_CreateOrder()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: "TestDb21")
            .Options;
            var options1 = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb21")
            .Options;
            var options2 = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb21")
            .Options;
            
            using(var context = new OrderContext(options))
            {
                using(var context1 = new StoreContext(options1))
                {
                    using(var context2 = new CustomerContext(options2))
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        context1.Database.EnsureDeleted();
                        context1.Database.EnsureCreated();
                        context2.Database.EnsureDeleted();
                        context2.Database.EnsureCreated();

                        OrderRepository orderRepo = new OrderRepository(context);
                        StoreRepository storeRepo = new StoreRepository(context1);
                        CustomerRepository custRepo = new CustomerRepository(context2);
                        OrderLogic ol = new OrderLogic(orderRepo, storeRepo, custRepo);

                        AStore store = new AStore();
                        Customer newCust = new Customer();
                        ItemType item = new ItemType("toppings");
                        APizzaComponent testCrust = new APizzaComponent("testcrust", item);
                        APizzaComponent testTopping = new APizzaComponent("testtopping", item);
                        APizzaComponent testSize = new APizzaComponent("testsize", item);
                        Crust tempCrust = new Crust(store, 0, 1, testCrust);
                        Topping tempTopping = new Topping(store, 0, 1, testTopping);
                        Size tempSize = new Size(store, 0, 1, testSize);

                        context1.Add<AStore>(store);
                        context2.Add<Customer>(newCust);
                        context1.Add<ItemType>(item);
                        context1.Add<APizzaComponent>(testCrust);
                        context1.Add<APizzaComponent>(testTopping);
                        context1.Add<APizzaComponent>(testSize);
                        context1.Add<Crust>(tempCrust);
                        context1.Add<Topping>(tempTopping);
                        context1.Add<Size>(tempSize);
                        context.SaveChanges();
                        context1.SaveChanges();
                        context2.SaveChanges();

                        RawPizza rawTest = new RawPizza();
                        rawTest.Name = "Test Pizza";
                        rawTest.Price = 0;
                        rawTest.Crust = "testcrust";
                        rawTest.Size = "testsize";
                        rawTest.Toppings = new List<string>();
                        rawTest.Toppings.Add("testtopping");

                        RawOrder newOrder = new RawOrder();
                        newOrder.PizzaList = new List<RawPizza>();
                        newOrder.StoreID = store.StoreID;
                        newOrder.CustomerID = newCust.CustomerID;
                        newOrder.Total = 0;
                        newOrder.PizzaList.Add(rawTest);

                        Order createOrder = ol.CreateOrder(newOrder);
                        Assert.NotNull(createOrder);
                    }
                }
            }
        }
    
        [Fact]
        public void Test_GetCustomerOrderHistory()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: "TestDb15")
            .Options;
            var options1 = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb15")
            .Options;
            var options2 = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb15")
            .Options;
            
            using(var context = new OrderContext(options))
            {
                using(var context1 = new StoreContext(options1))
                {
                    using(var context2 = new CustomerContext(options2))
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        context1.Database.EnsureDeleted();
                        context1.Database.EnsureCreated();
                        context2.Database.EnsureDeleted();
                        context2.Database.EnsureCreated();

                        OrderRepository orderRepo = new OrderRepository(context);
                        StoreRepository storeRepo = new StoreRepository(context1);
                        CustomerRepository custRepo = new CustomerRepository(context2);
                        OrderLogic ol = new OrderLogic(orderRepo, storeRepo, custRepo);

                        AStore store = new AStore();
                        Customer newCust = new Customer();
                        
                        Order testOrder = new Order();
                        testOrder.Store = store.StoreID;
                        testOrder.Cust = newCust.CustomerID;
                        testOrder.JSONPizzaOrder = "this is a test order for customers";

                        context.Add<Order>(testOrder);
                        context1.Add<AStore>(store);
                        context2.Add<Customer>(newCust);
                        context.SaveChanges();
                        context1.SaveChanges();
                        context2.SaveChanges();

                        RawOrderHistory createOrder = ol.GetCustomerOrderHistory(newCust.CustomerID);
                        Assert.Equal(testOrder.JSONPizzaOrder, createOrder.jsonPizzaOrders[0]);
                    }
                }
            }
        }
    
        [Fact]
        public void Test_GetStoreOrderHistory()
        {
            var options = new DbContextOptionsBuilder<OrderContext>()
            .UseInMemoryDatabase(databaseName: "TestDb20")
            .Options;
            var options1 = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb20")
            .Options;
            var options2 = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb20")
            .Options;
            
            using(var context = new OrderContext(options))
            {
                using(var context1 = new StoreContext(options1))
                {
                    using(var context2 = new CustomerContext(options2))
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                        context1.Database.EnsureDeleted();
                        context1.Database.EnsureCreated();
                        context2.Database.EnsureDeleted();
                        context2.Database.EnsureCreated();

                        OrderRepository orderRepo = new OrderRepository(context);
                        StoreRepository storeRepo = new StoreRepository(context1);
                        CustomerRepository custRepo = new CustomerRepository(context2);
                        OrderLogic ol = new OrderLogic(orderRepo, storeRepo, custRepo);

                        AStore store = new AStore();
                        Customer newCust = new Customer();
                        
                        Order testOrder = new Order();
                        testOrder.Store = store.StoreID;
                        testOrder.Cust = newCust.CustomerID;
                        testOrder.JSONPizzaOrder = "this is a test order for store";

                        context.Add<Order>(testOrder);
                        context1.Add<AStore>(store);
                        context2.Add<Customer>(newCust);
                        context.SaveChanges();
                        context1.SaveChanges();
                        context2.SaveChanges();

                        RawOrderHistory createOrder = ol.GetStoreOrderHistory(store.StoreID);
                        Assert.Equal(testOrder.JSONPizzaOrder, createOrder.jsonPizzaOrders[0]);
                    }
                }
            }
        }
    }
}
