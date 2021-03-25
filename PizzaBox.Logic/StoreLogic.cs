using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Repository;

namespace PizzaBox.Logic
{
    public class StoreLogic
    {
        private readonly StoreRepository storeRepo;
        public StoreLogic(StoreRepository r)
        {
            storeRepo = r;
        }

        public List<AStore> GetStores()
        {
            List<AStore> temp = storeRepo.GetStores();
            temp.Add(new ChicagoStore());
            return temp;
        }
    }
}
