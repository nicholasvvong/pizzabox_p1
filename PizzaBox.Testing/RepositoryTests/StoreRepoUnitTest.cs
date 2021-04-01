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
    public class StoreRepoUnitTest
    {
        [Fact]
        public void Test_GetStores()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb0")
            .Options;

            AStore store1 = new AStore();
            store1.Name = "Store1";
            
            using(var context = new StoreContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Add<AStore>(store1);
                context.SaveChanges();
            }

            using(var context = new StoreContext(options))
            {
                StoreRepository storeRepo = new StoreRepository(context);

                AStore store2 = new AStore();
                store2.Name = "Store1";

                List<AStore> stores = storeRepo.GetStores();
                
                Assert.Equal(store2.Name, stores[0].Name);
            }
        }

        [Fact]
        public void Test_UpdateToppingInventory()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb1")
            .Options;

            AStore store = new AStore();
            Topping t = new Topping(store, 0, 100, "Test Topping", new ItemType());
            store.ToppingsList.Add(t);
            int expected = 99;
            using(var context = new StoreContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Add<AStore>(store);
                context.SaveChanges();
            }

            using(var context = new StoreContext(options))
            {
                StoreRepository storeRepo = new StoreRepository(context);
                
                storeRepo.UpdateToppingInventory(store.StoreID, t.PizzaType.Name, expected);

                var test = context.Toppings.SingleOrDefault(n => n.PizzaType.Name == t.PizzaType.Name);

                Assert.Equal(expected, test.Inventory);
            }
        }

        [Fact]
        public void Test_AddPizzaToStore()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb2")
            .Options;

            AStore store = new AStore();
            BasicPizza newPizza = new BasicPizza();
            newPizza.Type = "Test Pizza";
            using(var context = new StoreContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Add<AStore>(store);
                context.SaveChanges();
            }

            using(var context = new StoreContext(options))
            {
                StoreRepository storeRepo = new StoreRepository(context);

                storeRepo.AddPizzaToStore(store.StoreID, newPizza);

                var pres = context.BasicPizza.SingleOrDefault(p => p.Type == newPizza.Type);

                Assert.Equal(pres.Type, newPizza.Type);
            }
        }
    }
}
