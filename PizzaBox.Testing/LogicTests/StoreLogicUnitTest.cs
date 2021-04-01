using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Logic;
using PizzaBox.Repository;
using Xunit;

namespace PizzaBox.Testing
{
    public class StoreLogicUnitTest
    {
        [Fact]
        public void Test_GetStoresStrings()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb12")
            .Options;
            
            using(var context = new StoreContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                StoreRepository storeRepo = new StoreRepository(context);
                StoreLogic sl = new StoreLogic(storeRepo);

                AStore store1 = new AStore();
                store1.Name = "Store1";
                AStore store2 = new AStore();
                store2.Name = "Store2";

                context.Add<AStore>(store1);
                context.Add<AStore>(store2);
                context.SaveChanges();

                Dictionary<string, Guid> stores = sl.GetStoresStrings();
                
                Assert.Equal(store1.StoreID, stores[store1.Name]);
            }
        }
    
        [Fact]
        public void Test_GetStore()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb13")
            .Options;
            
            using(var context = new StoreContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                StoreRepository storeRepo = new StoreRepository(context);
                StoreLogic sl = new StoreLogic(storeRepo);

                AStore store1 = new AStore();
                store1.Name = "Store1";

                context.Add<AStore>(store1);
                context.SaveChanges();

                AStore stores = sl.GetStore(store1.StoreID);
                
                Assert.Equal(store1.Name, stores.Name);
            }
        }
    
        [Fact]
        public void Test_AddNewComp()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb14")
            .Options;
            
            using(var context = new StoreContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                StoreRepository storeRepo = new StoreRepository(context);
                StoreLogic sl = new StoreLogic(storeRepo);

                AStore store = new AStore();
                store.Name = "Store1";
                ItemType item = new ItemType("toppings");
                APizzaComponent testComp = new APizzaComponent("test", item);

                context.Add<AStore>(store);
                context.Add<ItemType>(item);
                context.Add<APizzaComponent>(testComp);
                context.SaveChanges();

                RawNewComp rawTest = new RawNewComp();
                rawTest.ID = store.StoreID;
                rawTest.ItemID = item.TypeID;
                rawTest.ItemName = item.Name;
                rawTest.CompName = "testcomp";
                rawTest.Price = 0;

                Assert.True(sl.AddNewComp(rawTest));
            }
        }
    
        [Fact]
        public void Test_AddNewPizza()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb16")
            .Options;
            
            using(var context = new StoreContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                StoreRepository storeRepo = new StoreRepository(context);
                StoreLogic sl = new StoreLogic(storeRepo);

                AStore store = new AStore();
                store.Name = "Store1";
                ItemType item = new ItemType("toppings");
                APizzaComponent testCrust = new APizzaComponent("testcrust", item);
                APizzaComponent testTopping = new APizzaComponent("testtopping", item);
                Crust tempCrust = new Crust(store, 0, 1, testCrust);
                Topping tempTopping = new Topping(store, 0, 1, testTopping);

                context.Add<AStore>(store);
                context.Add<ItemType>(item);
                context.Add<APizzaComponent>(testCrust);
                context.Add<APizzaComponent>(testTopping);
                context.Add<Crust>(tempCrust);
                context.Add<Topping>(tempTopping);
                context.SaveChanges();

                RawComp rawCrust = new RawComp();
                rawCrust.ID = tempCrust.CrustID;
                rawCrust.Inventory = 0;
                rawCrust.Name = "testcrust";
                rawCrust.Price = 0;

                RawComp rawTopping = new RawComp();
                rawTopping.ID = tempTopping.ToppingID;
                rawTopping.Inventory = 0;
                rawTopping.Name = "testtopping";
                rawTopping.Price = 0;

                RawNewPizza rawTest = new RawNewPizza();
                rawTest.ID = store.StoreID;
                rawTest.Name = "testpizza";
                rawTest.Crust = rawCrust;
                rawTest.AllToppings = new List<RawComp>();
                rawTest.AllToppings.Add(rawTopping);

                Assert.True(sl.AddNewPizza(rawTest));
            }
        }
    
        [Fact]
        public void Test_GetStoreToppings()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb15")
            .Options;
            
            using(var context = new StoreContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                StoreRepository storeRepo = new StoreRepository(context);
                StoreLogic sl = new StoreLogic(storeRepo);

                AStore store1 = new AStore();
                store1.Name = "Store1";
                ItemType type = new ItemType("testtype");
                APizzaComponent comp = new APizzaComponent("testcomp", type);
                Topping testtopping = new Topping(store1, 0, 0, comp);

                context.Add<AStore>(store1);
                context.Add<Topping>(testtopping);
                context.SaveChanges();

                List<Topping> toppings = sl.GetStoreToppings(store1.StoreID);
                
                Assert.Equal(testtopping.PizzaType.Name, toppings[0].PizzaType.Name);
            }
        }
    }
}
