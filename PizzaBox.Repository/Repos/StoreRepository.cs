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
            List<AStore> stores = new List<AStore>();
            stores.Add(new FreddyStore());
            InitStores();
            return stores;
        }

        private void InitStores()
        {
            AStore cpk = new CaliforniaStore();
            AStore store = context.Stores.SingleOrDefault(name => name.Name == "CPK");
            Guid sID = Guid.NewGuid();
            
            if(store is AStore)
            {
                sID = store.StoreID;
                Console.WriteLine(sID);
                // foreach(Topping t in cpk.ToppingsList)
                // {
                //     APizzaComponent compExist = context.Comps.SingleOrDefault(name => name.Name == t.Name);
                //     if(compExist is APizzaComponent)
                //     {
                //         Guid compID = compExist.CompID;
                //         t.StoreID = sID;
                //         t.CompID = compID;
                //         t.ToppingID = Guid.NewGuid();
                //         context.Add<Topping>(t);
                //     }
                // }
            }

            context.SaveChanges();
        }
    }
}