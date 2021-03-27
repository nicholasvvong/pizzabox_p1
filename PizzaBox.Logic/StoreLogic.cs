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
        public Dictionary<string, Guid> GetStoresStrings()
        {
            List<AStore> temp = storeRepo.GetStores();
            Dictionary<string, Guid> stringStores = new Dictionary<string, Guid>();
            foreach(AStore store in temp)
            {
                stringStores.Add(store.Name, store.StoreID);
            }
            return stringStores;
        }

        public AStore GetStoreObject(Guid id)
        {
            AStore returnStore = new AStore();
            returnStore.Name = storeRepo.GetName(id);
            returnStore.MaxPizzas = storeRepo.GetMaxPizzas(id);
            returnStore.MaxToppings = storeRepo.GetMaxToppings(id);
            returnStore.MaxPrice = storeRepo.GetMaxPrice(id);
            returnStore.CrustList = storeRepo.GetCrusts(id);
            // returnStore.SizeList = storeRepo.GetSizes(id);
            // returnStore.ToppingsList = storeRepo.GetToppings(id);
            // returnStore.PresetPizzas = storeRepo.GetPresets(id);
            return returnStore;
        }
    }
}
