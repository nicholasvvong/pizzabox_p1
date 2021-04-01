using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Repository
{
    public class StoreRepository
    {
        private readonly StoreContext context;

        public StoreRepository(StoreContext c)
        {
            context = c;
        }

        private void StoresInit()
        {
            CaliforniaStore cpk = new CaliforniaStore();
            context.Add<AStore>(cpk);
            context.SaveChanges();
            InitChicagoStore();
            InitFreddyStore();
            InitNewYorkStore();
        }

        /// <summary>
        /// Gets all the stores in the database
        /// </summary>
        /// <returns>List of AStores</returns>
        public List<AStore> GetStores()
        {
            List<AStore> stores = context.Stores.ToList();
            //StoresInit();
            return stores;
        }

        /// <summary>
        /// Gets all the itemtypes in the database(topping, crust, size)
        /// </summary>
        /// <returns>List of itemtypes</returns>
        public List<ItemType> GetItemTypes()
        {
            var findItems = context.ItemTypes.ToList();
            return findItems;
        }

        /// <summary>
        /// Gets the max pizza per order a store allows based off store's id
        /// </summary>
        /// <param name="id">Store's Guid</param>
        /// <returns>Max # of pizzas</returns>
        public int GetMaxPizzas(Guid id)
        {
            AStore store = context.Stores.SingleOrDefault(n => Guid.Equals(n.StoreID, id));
            if(store is AStore)
            {
                return store.MaxPizzas;
            }
            return -1;
        }

        /// <summary>
        /// Updates the store's inventory after an order has been submitted
        /// Goes throuhgh each pizza and decrments from database
        /// </summary>
        /// <param name="pizzaList">List of pizzas from order</param>
        public void UpdateInventory(Guid StoreID, List<RawPizza> pizzaList)
        {
            foreach(RawPizza rp in pizzaList)
            {
                DecrementSize(StoreID, rp.Size);
                DecrementCrust(StoreID, rp.Crust);
                foreach(string t in rp.Toppings)
                {
                    Console.WriteLine("-----------" + t);
                    DecrementTopping(StoreID, t);
                }
            }
        }

        /// <summary>
        /// Gets the max number of toppings allowed per pizza for a store
        /// </summary>
        /// <param name="id">Store's Guid id</param>
        /// <returns>Max # of toppings per pizza</returns>
        public int GetMaxToppings(Guid id)
        {
            AStore store = context.Stores.SingleOrDefault(n => Guid.Equals(n.StoreID, id));
            if(store is AStore)
            {
                return store.MaxToppings;
            }
            return -1;
        }

        public void AddNewTopping(Topping t)
        {
            context.Add<Topping>(t);
            context.SaveChanges();
        }

        /// <summary>
        /// Gets all the crusts a store offers
        /// </summary>
        /// <param name="id">Store's ID</param>
        /// <returns>List of crusts</returns>
        public List<Crust> GetCrusts(Guid id)
        {
            List<Crust> CrustList = new List<Crust>();
            CrustList = context.Crusts.Include(c => c.PizzaType).Where(n => Guid.Equals(n.Store.StoreID, id)).ToList();
            return CrustList;
        }

        /// <summary>
        /// Gets the pizza component from the database, if it exists
        /// If it does not exist, return null
        /// </summary>
        /// <param name="compName">Name of the component</param>
        /// <returns></returns>
        public APizzaComponent GetPizzaComp(string compName)
        {
            var pizzaComp = context.Comps.SingleOrDefault(n => n.Name == compName);

            return pizzaComp;
        }

        /// <summary>
        /// Adds a new APizzaComponent to the database.
        /// Returns the newly added APizzaComponent if successful, else null
        /// </summary>
        /// <param name="newComp">New APizzaComponent</param>
        /// <returns></returns>
        public APizzaComponent AddPizzaComp(APizzaComponent newComp)
        {
            context.Add<APizzaComponent>(newComp);
            context.SaveChanges();

            var newlyAddedComp = context.Comps.SingleOrDefault(n => Guid.Equals(n.CompID, newComp.CompID));
            return newlyAddedComp;
        }

        /// <summary>
        /// Gets a crust information by its ID
        /// </summary>
        /// <param name="iD">Crust ID</param>
        /// <returns>Crust from database</returns>
        public Crust GetCrustByID(Guid id)
        {
            var getCrust = context.Crusts.SingleOrDefault(n => Guid.Equals(n.CrustID, id));
            return getCrust;
        }

        /// <summary>
        /// Gets a topping information by its ID
        /// </summary>
        /// <param name="iD">Topping ID</param>
        /// <returns>Topping from database</returns>
        public Topping GetToppingByID(Guid id)
        {
            var getTopping = context.Toppings.SingleOrDefault(n => Guid.Equals(n.ToppingID, id));
            return getTopping;
        }

        /// <summary>
        /// Updates database with any changes made to a store outside of repository
        /// </summary>
        public void UpdateStore(AStore curStore)
        {
            // context.Stores.Attach(curStore);
            // context.Entry(curStore).Collection(p => p.PresetPizzas).IsModified = true;
            // context.Stores.Update(curStore);
            // context.SaveChanges();
        }

        /// <summary>
        /// Adds the new pizza into the database
        /// Then adds the new pizza to the preset of the store afterwards
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <param name="bp">New Pizza</param>
        /// <returns></returns>
        public bool AddPizzaToStore(Guid id, BasicPizza bp)
        {
            var getStore = context.Stores.Include(s => s.PresetPizzas).SingleOrDefault(n => Guid.Equals(n.StoreID, id));
            if(getStore is null)
            {
                return false;
            }
            getStore.PresetPizzas.Add(bp);

            context.Entry(bp).State = EntityState.Added;
            context.BasicPizza.Add(bp);

            context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Returns the base item type that's in the database(topping, crust, size) based off ID
        /// </summary>
        /// <param name="itemID">Item ID</param>
        /// <returns></returns>
        public ItemType GetBaseItem(Guid itemID)
        {
            var itembase = context.ItemTypes.SingleOrDefault(n => Guid.Equals(n.TypeID, itemID));

            return itembase;
        }

        /// <summary>
        /// Gets all the toppings a store offers
        /// </summary>
        /// <param name="id">Store's ID</param>
        /// <returns>List of Toppings</returns>
        public List<Topping> GetToppings(Guid id)
        {
            List<Topping> ToppingsList = new List<Topping>();
            ToppingsList = context.Toppings.Include(c => c.PizzaType).Where(n => Guid.Equals(n.Store.StoreID, id)).ToList();
            return ToppingsList;
        }

        /// <summary>
        /// Gets all the premade pizzas a store offers
        /// </summary>
        /// <param name="id">Store's ID</param>
        /// <returns>List of BasicPizzas</returns>
        public List<BasicPizza> GetPresets(Guid id)
        {
            var pre = context.Stores.Include(s => s.PresetPizzas).ThenInclude(top => top.Toppings).ThenInclude(comp => comp.PizzaType)
                                    .Include(st => st.PresetPizzas).ThenInclude(ts => ts.Crust).ThenInclude(comp => comp.PizzaType)
                        .Where(st => Guid.Equals(st.StoreID, id)).Select(p => p.PresetPizzas);
            var list = pre.ToList();
            
            return list[0];
        }

        /// <summary>
        /// Adds a new crust to the store database
        /// </summary>
        /// <param name="newCrust">New Crust</param>
        public void AddNewCrust(Crust newCrust)
        {
            context.Add<Crust>(newCrust);
            context.SaveChanges();
        }

        /// <summary>
        /// Gets all the sizes a store offers
        /// </summary>
        /// <param name="id">Store's ID</param>
        /// <returns>List of Sizes</returns>
        public List<Size> GetSizes(Guid id)
        {
            List<Size> SizeList = new List<Size>();
            SizeList = context.Sizes.Include(s => s.PizzaType).Where(n => Guid.Equals(n.Store.StoreID, id)).ToList();
            return SizeList;
        }

        /// <summary>
        /// Adds a new size to the store database
        /// </summary>
        /// <param name="newSize">New size</param>
        public void AddNewSize(Size newSize)
        {
            context.Add<Size>(newSize);
            context.SaveChanges();
        }

        /// <summary>
        /// Gets the name of a store based off the id
        /// </summary>
        /// <param name="id">Store's ID</param>
        /// <returns>Name of the store</returns>
        public string GetName(Guid id)
        {
            AStore store = context.Stores.SingleOrDefault(n => Guid.Equals(n.StoreID, id));
            if(store is AStore)
            {
                return store.Name;
            }
            return "";
        }

        /// <summary>
        /// Gets the max price per order a store will allow
        /// </summary>
        /// <param name="id">Store's ID</param>
        /// <returns>Max price per order</returns>
        public decimal GetMaxPrice(Guid id)
        {
            AStore store = context.Stores.SingleOrDefault(n => Guid.Equals(n.StoreID, id));
            if(store is AStore)
            {
                return store.MaxPrice;
            }
            return -1;
        }

        /// <summary>
        /// Finds a store in a database based off the id
        /// Returns the store if found. Returns null if the store was not found
        /// </summary>
        /// <param name="id">Store's ID</param>
        /// <returns>AStore if found, else null</returns>
        public AStore FindStore(Guid id)
        {
            var store = context.Stores.SingleOrDefault(n => Guid.Equals(n.StoreID, id));
            if(store is AStore)
            {
                return store;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Searches database for the size-store pair and decreases inventory by 1
        /// </summary>
        /// /// <param name="id">Store iD</param>
        /// <param name="size">Name of the size</param>
        private void DecrementSize(Guid id, string size)
        {
            var currentInventoryAmounts =  context.Sizes.Include(c => c.PizzaType)
                                .Include(st => st.Store)
                                .Where(s => s.PizzaType.Name == size)
                                .Where(s => s.Store.StoreID == id)
                                .Select(i => i.Inventory).FirstOrDefault();
            Console.WriteLine(currentInventoryAmounts);
            UpdateSizeInventory(id, size, currentInventoryAmounts - 1);
        }

        /// <summary>
        /// Searches database for the crust-store pair and decreases inventory by 1
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <param name="crust">Name of the crust</param>
        private void DecrementCrust(Guid id, string crust)
        {
            var currentInventoryAmounts =  context.Crusts.Include(c => c.PizzaType)
                                .Include(st => st.Store)
                                .Where(s => s.PizzaType.Name == crust)
                                .Where(s => s.Store.StoreID == id)
                                .Select(i => i.Inventory).FirstOrDefault();
            Console.WriteLine(currentInventoryAmounts);
            UpdateCrustInventory(id, crust, currentInventoryAmounts - 1);
        }
        
        /// <summary>
        /// Searches databse for the topping-store pair and decreases its inventory by 1
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <param name="topping">Name of Topping</param>
        private void DecrementTopping(Guid id, string topping)
        {
            var currentInventoryAmounts =  context.Toppings.Include(c => c.PizzaType)
                                .Include(st => st.Store)
                                .Where(s => s.PizzaType.Name == topping)
                                .Where(s => s.Store.StoreID == id)
                                .Select(i => i.Inventory).FirstOrDefault();
            Console.WriteLine(currentInventoryAmounts);
            UpdateToppingInventory(id, topping, currentInventoryAmounts - 1);
        }

        /// <summary>
        /// Updates the inventory of sizes to a set amount
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <param name="size">Size to update</param>
        /// <param name="v">New inventory amount</param>
        public void UpdateSizeInventory(Guid id, string size, int v)
        {
            var sizeEntry = context.Sizes.Include(c => c.PizzaType) 
                                .Include(st => st.Store)
                                .Where(s => s.PizzaType.Name == size)
                                .Where(s => s.Store.StoreID == id).FirstOrDefault();
            sizeEntry.Inventory = v;
            context.SaveChanges();
            //context.Entry(sizeEntry).CurrentValues.SetValues(v);
        }

        /// <summary>
        /// Updates the price of sizes to a set amount
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <param name="size">Size to update</param>
        /// <param name="v">New price amount</param>
        public void UpdateSizePrice(Guid id, string size, decimal price)
        {
            var sizeEntry = context.Sizes.Include(c => c.PizzaType) 
                                .Include(st => st.Store)
                                .Where(s => s.PizzaType.Name == size)
                                .Where(s => s.Store.StoreID == id).FirstOrDefault();
            sizeEntry.Price = price;
            context.SaveChanges();
            //context.Entry(sizeEntry).CurrentValues.SetValues(v);
        }

        /// <summary>
        /// Updates the inventory of crust to a set amount
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <param name="crust">Crust Name</param>
        /// <param name="v">New inventory amount</param>
        public void UpdateCrustInventory(Guid id, string crust, int v)
        {
            var crustEntry = context.Crusts.Include(c => c.PizzaType) 
                                .Include(st => st.Store)
                                .Where(s => s.PizzaType.Name == crust)
                                .Where(s => s.Store.StoreID == id).FirstOrDefault();
            if(crustEntry is null) 
            {
                Console.WriteLine("Could not find this crust " + crust);
                return;
            }
            crustEntry.Inventory = v;
            context.SaveChanges();
            //context.Entry(sizeEntry).CurrentValues.SetValues(v);
        }

        /// <summary>
        /// Updates the price of a crust to a set amount
        /// </summary>
        /// <param name="storeID">Store ID</param>
        /// <param name="name">Name of crust</param>
        /// <param name="price">New price of crust</param>
        public void UpdateCrustPrice(Guid id, string crust, decimal price)
        {
            var crustEntry = context.Crusts.Include(c => c.PizzaType) 
                                .Include(st => st.Store)
                                .Where(s => s.PizzaType.Name == crust)
                                .Where(s => s.Store.StoreID == id).FirstOrDefault();
            crustEntry.Price = price;
            context.SaveChanges();
        }

        /// <summary>
        /// Updates the inventory of a topping to a set amount
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <param name="topping">Topping Name</param>
        /// <param name="v">New inventory amount</param>
        public void UpdateToppingInventory(Guid id, string topping, int v)
        {
            Console.WriteLine(id);
            Console.WriteLine(topping);
            Console.WriteLine(v);
            var toppingEntry = context.Toppings.Include(c => c.PizzaType) 
                                .Include(st => st.Store)
                                .Where(s => s.PizzaType.Name == topping)
                                .Where(s => s.Store.StoreID == id).FirstOrDefault();
            toppingEntry.Inventory = v;
            context.SaveChanges();
            //context.Entry(sizeEntry).CurrentValues.SetValues(v);
        }

        /// <summary>
        /// Updates the price of a topping to a set amount
        /// </summary>
        /// <param name="storeID">Store ID</param>
        /// <param name="name">Name of topping</param>
        /// <param name="price">New price of topping</param>
        public void UpdateToppingPrice(Guid id, string topping, decimal price)
        {
            var toppingEntry = context.Toppings.Include(c => c.PizzaType) 
                                .Include(st => st.Store)
                                .Where(s => s.PizzaType.Name == topping)
                                .Where(s => s.Store.StoreID == id).FirstOrDefault();
            toppingEntry.Price = price;
            context.SaveChanges();
        }

        //------------------------------------------------------------------------------------------------------------------------------//
        private void InitChicagoStore()
        {
            Dictionary<string, decimal> chicagoToppings = new Dictionary<string, decimal>();
            chicagoToppings.Add("beef", 0.75m);
            chicagoToppings.Add("chicken", 1.50m);
            chicagoToppings.Add("ham", 0.57m);
            chicagoToppings.Add("mushroom", 0.45m);
            chicagoToppings.Add("olive", 0.25m);
            chicagoToppings.Add("peppers", 0.30m);
            chicagoToppings.Add("pineapple", 0.50m);
            chicagoToppings.Add("pepporoni", 0.25m);
            chicagoToppings.Add("salami", 0.70m);
            chicagoToppings.Add("sausage", 0.70m);
            chicagoToppings.Add("bacon", 0.50m);
            chicagoToppings.Add("onion", 1.00m);
            Dictionary<string, decimal> chicagoSize = new Dictionary<string, decimal>();
            chicagoSize.Add("small", 4.50m);
            chicagoSize.Add("medium", 5.50m);
            chicagoSize.Add("large", 6.50m);
            Dictionary<string, decimal> chicagoCrust = new Dictionary<string, decimal>();
            chicagoCrust.Add("regular", 0.50m);
            chicagoCrust.Add("hand-tossed", 1.00m);
            chicagoCrust.Add("thin", 0.50m);

            ChicagoStore initChicago = new ChicagoStore();
            initChicago.MaxPizzas = 50;
            initChicago.MaxPrice = 200.00m;
            initChicago.MaxToppings = 4;

            foreach(KeyValuePair<string, decimal> kvp in chicagoToppings)
            {
                string topping = kvp.Key;
                decimal value = kvp.Value;
                var curComp = context.Comps.SingleOrDefault(n => n.Name == topping);
                if(curComp is null)
                {
                    var curType = context.ItemTypes.SingleOrDefault(n => n.Name == "toppings");
                    APizzaComponent newComp = new APizzaComponent(kvp.Key, curType);
                    context.Add<APizzaComponent>(newComp);
                    context.SaveChanges();
                }
                var forsureComp = context.Comps.SingleOrDefault(n => n.Name == topping);
                initChicago.ToppingsList.Add(new Topping(initChicago, value, 100, forsureComp));
            }

            foreach(KeyValuePair<string, decimal> kvp in chicagoCrust)
            {
                string crust = kvp.Key;
                decimal value = kvp.Value;
                var curComp = context.Comps.SingleOrDefault(n => n.Name == crust);
                if(curComp is null)
                {
                    var curType = context.ItemTypes.SingleOrDefault(n => n.Name == "crust");
                    APizzaComponent newComp = new APizzaComponent(kvp.Key, curType);
                    context.Add<APizzaComponent>(newComp);
                    context.SaveChanges();
                }
                var forsureComp = context.Comps.SingleOrDefault(n => n.Name == crust);
                initChicago.CrustList.Add(new Crust(initChicago, value, 100, forsureComp));
            }

            foreach(KeyValuePair<string, decimal> kvp in chicagoSize)
            {
                string size = kvp.Key;
                decimal value = kvp.Value;
                var curComp = context.Comps.SingleOrDefault(n => n.Name == size);
                if(curComp is null)
                {
                    var curType = context.ItemTypes.SingleOrDefault(n => n.Name == "size");
                    APizzaComponent newComp = new APizzaComponent(kvp.Key, curType);
                    context.Add<APizzaComponent>(newComp);
                    context.SaveChanges();
                }
                var forsureComp = context.Comps.SingleOrDefault(n => n.Name == size);
                initChicago.SizeList.Add(new Size(initChicago, value, 100, forsureComp));
            }

            initChicago.InitPresetPizza();

            context.Add<AStore>(initChicago);
            context.SaveChanges();
        }
        private void InitFreddyStore()
        {
            Dictionary<string, decimal> toppings = new Dictionary<string, decimal>();
            toppings.Add("onions", 0.75m);
            toppings.Add("tomatoes", 1.50m);
            toppings.Add("spinach", 0.57m);
            toppings.Add("mushroom", 0.45m);
            toppings.Add("olive", 0.25m);
            toppings.Add("peppers", 0.30m);
            toppings.Add("pineapple", 0.50m);
            Dictionary<string, decimal> sizes = new Dictionary<string, decimal>();
            sizes.Add("medium", 5.00m);
            sizes.Add("large", 6.00m);
            Dictionary<string, decimal> crusts = new Dictionary<string, decimal>();
            crusts.Add("regular", 0.50m);
            crusts.Add("hand-tossed", 1.00m);
            crusts.Add("thin", 0.50m);
            //3, 100.00, 20
            AStore tempStore = InitNewStore("Freddy's Pizza Store", 10, 3, 100.00m, toppings, crusts, sizes);

            BasicPizza tempP = new BasicPizza();
            tempP.Type = "Basic Veggie Pizza";
            tempP.AddCrust(tempStore.CrustList[0]);
            tempP.AddTopping(tempStore.ToppingsList[0]);
            tempP.AddTopping(tempStore.ToppingsList[1]);
            tempP.AddTopping(tempStore.ToppingsList[4]);
            tempP.AddTopping(tempStore.ToppingsList[6]);
            //tempP.CalculatePrice();
            tempStore.PresetPizzas.Add(tempP);

            context.Add<AStore>(tempStore);
            context.SaveChanges();
        }
        private void InitNewYorkStore()
        {
            Random rng = new Random();
            Dictionary<string, decimal> toppings = new Dictionary<string, decimal>();
            toppings.Add("beef", (rng.Next(1, 101)/100.0m));
            toppings.Add("chicken", (rng.Next(1, 101)/100.0m));
            toppings.Add("ham", (rng.Next(1, 101)/100.0m));
            toppings.Add("mushroom", (rng.Next(1, 101)/100.0m));
            toppings.Add("olive", (rng.Next(1, 101)/100.0m));
            toppings.Add("peppers", (rng.Next(1, 101)/100.0m));
            toppings.Add("pineapple", (rng.Next(1, 101)/100.0m));
            toppings.Add("pepporoni", (rng.Next(1, 101)/100.0m));
            toppings.Add("salami", (rng.Next(1, 101)/100.0m));
            toppings.Add("sausage", (rng.Next(1, 101)/100.0m));
            toppings.Add("meat ball", (rng.Next(1, 101)/100.0m));
            toppings.Add("anchovies", (rng.Next(1, 101)/100.0m));
            Dictionary<string, decimal> sizes = new Dictionary<string, decimal>();
            sizes.Add("small", 4.50m);
            sizes.Add("large", 5.50m);
            sizes.Add("extra large", 6.50m);
            Dictionary<string, decimal> crusts = new Dictionary<string, decimal>();
            crusts.Add("regular", 1.00m);
            crusts.Add("hand-tossed", 1.00m);
            crusts.Add("thin", 1.00m);
            //7, 250.00, 50)
            AStore tempStore = InitNewStore("NewYork Pizza Store", 50, 7, 200.0m, toppings, crusts, sizes);

            //     /*Meat*/
            BasicPizza tempP = new BasicPizza();
            tempP.Type = "Meat Pizza";
            tempP.AddCrust(tempStore.CrustList[0]);
            tempP.AddTopping(tempStore.ToppingsList[0]);
            tempP.AddTopping(tempStore.ToppingsList[1]);
            tempP.AddTopping(tempStore.ToppingsList[2]);
            tempP.AddTopping(tempStore.ToppingsList[6]);
            tempP.AddTopping(tempStore.ToppingsList[8]);
            //tempP.CalculatePrice();
            tempStore.PresetPizzas.Add(tempP);
            /*Hawaiian*/
            tempP = new BasicPizza();
            tempP.Type = "Hawaiian Pizza";
            tempP.AddCrust(tempStore.CrustList[0]);
            tempP.AddTopping(tempStore.ToppingsList[2]);
            tempP.AddTopping(tempStore.ToppingsList[5]);
            tempP.AddTopping(tempStore.ToppingsList[7]);
            //tempP.CalculatePrice();
            tempStore.PresetPizzas.Add(tempP);
            /*Deluxe*/
            tempP = new BasicPizza();
            tempP.Type = "Deluxe Pizza";
            tempP.AddCrust(tempStore.CrustList[0]);
            tempP.AddTopping(tempStore.ToppingsList[6]);
            tempP.AddTopping(tempStore.ToppingsList[9]);
            tempP.AddTopping(tempStore.ToppingsList[3]);
            tempP.AddTopping(tempStore.ToppingsList[5]);
            tempP.AddTopping(tempStore.ToppingsList[11]);
            //tempP.CalculatePrice();
            tempStore.PresetPizzas.Add(tempP);

            context.Add<AStore>(tempStore);
            context.SaveChanges();
        }
        private AStore InitNewStore(string name, int maxPizzas, int maxToppings, decimal maxPrice, Dictionary<string, decimal> toppings, Dictionary<string, decimal> crusts, Dictionary<string, decimal> sizes)
        {
            AStore initStore = new AStore();
            initStore.Name = name;
            initStore.MaxPizzas = maxPizzas;
            initStore.MaxPrice = maxPrice;
            initStore.MaxToppings = maxToppings;

            foreach(KeyValuePair<string, decimal> kvp in toppings)
            {
                string topping = kvp.Key;
                decimal value = kvp.Value;
                var curComp = context.Comps.SingleOrDefault(n => n.Name == topping);
                if(curComp is null)
                {
                    var curType = context.ItemTypes.SingleOrDefault(n => n.Name == "toppings");
                    APizzaComponent newComp = new APizzaComponent(kvp.Key, curType);
                    context.Add<APizzaComponent>(newComp);
                    context.SaveChanges();
                }
                var forsureComp = context.Comps.SingleOrDefault(n => n.Name == topping);
                initStore.ToppingsList.Add(new Topping(initStore, value, 100, forsureComp));
            }

            foreach(KeyValuePair<string, decimal> kvp in crusts)
            {
                string crust = kvp.Key;
                decimal value = kvp.Value;
                var curComp = context.Comps.SingleOrDefault(n => n.Name == crust);
                if(curComp is null)
                {
                    var curType = context.ItemTypes.SingleOrDefault(n => n.Name == "crust");
                    APizzaComponent newComp = new APizzaComponent(kvp.Key, curType);
                    context.Add<APizzaComponent>(newComp);
                    context.SaveChanges();
                }
                var forsureComp = context.Comps.SingleOrDefault(n => n.Name == crust);
                initStore.CrustList.Add(new Crust(initStore, value, 100, forsureComp));
            }

            foreach(KeyValuePair<string, decimal> kvp in sizes)
            {
                string size = kvp.Key;
                decimal value = kvp.Value;
                var curComp = context.Comps.SingleOrDefault(n => n.Name == size);
                if(curComp is null)
                {
                    var curType = context.ItemTypes.SingleOrDefault(n => n.Name == "size");
                    APizzaComponent newComp = new APizzaComponent(kvp.Key, curType);
                    context.Add<APizzaComponent>(newComp);
                    context.SaveChanges();
                }
                var forsureComp = context.Comps.SingleOrDefault(n => n.Name == size);
                initStore.SizeList.Add(new Size(initStore, value, 100, forsureComp));
            }

            return initStore;
            // context.Add<AStore>(initStore);
            // context.SaveChanges();
        }
    }
}