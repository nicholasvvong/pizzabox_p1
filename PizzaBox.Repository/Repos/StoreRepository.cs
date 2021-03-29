using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Microsoft.Data.SqlClient;

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
            // CaliforniaStore cpk = new CaliforniaStore();
            // context.Add<AStore>(cpk);
            // InitChicagoStore();
            // InitFreddyStore();
            // InitNewYorkStore();
        }

        public void AddTopping(string name, APizzaComponent apc)
        {
            
        }

        public List<AStore> GetStores()
        {
            List<AStore> stores = context.Stores.ToList();
            // StoresInit();
            return stores;
        }
        public int GetMaxPizzas(Guid id)
        {
            AStore store = context.Stores.SingleOrDefault(id => Guid.Equals(id.StoreID, id));
            if(store is AStore)
            {
                return store.MaxPizzas;
            }
            return -1;
        }

        public int GetMaxToppings(Guid id)
        {
            AStore store = context.Stores.SingleOrDefault(id => Guid.Equals(id.StoreID, id));
            if(store is AStore)
            {
                return store.MaxToppings;
            }
            return -1;
        }

        public IList<Crust> GetCrusts(Guid id)
        {
            List<Crust> CrustList = new List<Crust>();
            CrustList = context.Crusts.Where(n => Guid.Equals(n.Store.StoreID, id)).ToList();
            return CrustList;
        }

        public IList<Topping> GetToppings(Guid id)
        {
            List<Topping> ToppingsList = new List<Topping>();
            ToppingsList = context.Toppings.Where(n => Guid.Equals(n.Store.StoreID, id)).ToList();
            return ToppingsList;
        }

        public IList<BasicPizza> GetPresets(Guid id)
        {
            List<BasicPizza> PresetPizzas = new List<BasicPizza>();


            return PresetPizzas;
        }

        public IList<Size> GetSizes(Guid id)
        {
            List<Size> SizeList = new List<Size>();
            SizeList = context.Sizes.Where(n => Guid.Equals(n.Store.StoreID, id)).ToList();
            return SizeList;
        }

        public string GetName(Guid id)
        {
            AStore store = context.Stores.SingleOrDefault(id => Guid.Equals(id.StoreID, id));
            if(store is AStore)
            {
                return store.Name;
            }
            return "";
        }

        public decimal GetMaxPrice(Guid id)
        {
            AStore store = context.Stores.SingleOrDefault(id => Guid.Equals(id.StoreID, id));
            if(store is AStore)
            {
                return store.MaxPrice;
            }
            return -1;
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
            Dictionary<string, decimal> chicagoCrust = new Dictionary<string, decimal>();
            chicagoCrust.Add("small", 4.50m);
            chicagoCrust.Add("medium", 5.50m);
            chicagoCrust.Add("large", 6.50m);
            Dictionary<string, decimal> chicagoSize = new Dictionary<string, decimal>();
            chicagoSize.Add("regular", 0.50m);
            chicagoSize.Add("hand-tossed", 1.00m);
            chicagoSize.Add("thin", 0.50m);

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
            Dictionary<string, decimal> crusts = new Dictionary<string, decimal>();
            crusts.Add("small", 4.50m);
            crusts.Add("large", 5.50m);
            crusts.Add("extra large", 6.50m);
            Dictionary<string, decimal> sizes = new Dictionary<string, decimal>();
            sizes.Add("regular", 1.00m);
            sizes.Add("hand-tossed", 1.00m);
            sizes.Add("thin", 1.00m);
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