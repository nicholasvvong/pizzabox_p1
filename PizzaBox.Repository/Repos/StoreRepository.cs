using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

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
            return stores;
        }
    }
}