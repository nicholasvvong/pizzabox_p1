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

        public List<AStore> GetStores()
        {
            List<AStore> stores = context.Stores.ToList();

            //InitStores();
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

        // private void InitStores()
        // {
        //     AStore cpk = new CaliforniaStore();
        //     AStore store = context.Stores.SingleOrDefault(name => name.Name == "CPK");
        //     Guid sID = Guid.NewGuid();

        //     if(store is AStore)
        //     {
        //         sID = store.StoreID;
        //         Console.WriteLine(sID);
        //         // foreach(Topping t in cpk.ToppingsList)
        //         // {
        //         //     APizzaComponent compExist = context.Comps.SingleOrDefault(name => name.Name == t.Name);
        //         //     if(compExist is APizzaComponent)
        //         //     {
        //         //         Guid compID = compExist.CompID;
        //         //         t.StoreID = sID;
        //         //         t.CompID = compID;
        //         //         t.ToppingID = Guid.NewGuid();
        //         //         context.Add<Topping>(t);
        //         //     }
        //         // }
        //     }

        //     context.SaveChanges();
        // }
    }
}