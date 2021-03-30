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

        public AStore GetStore(Guid id)
        {
            AStore returnStore = storeRepo.FindStore(id);

            return returnStore;
        }

        public List<Topping> GetStoreToppings(Guid id)
        {
            List<Topping> toppings = storeRepo.GetToppings(id);

            return toppings;
        }

        public List<Crust> GetStoreCrusts(Guid id)
        {
            List<Crust> toppings = storeRepo.GetCrusts(id);

            return toppings;
        }

        public List<Size> GetStoreSizes(Guid id)
        {
            List<Size> toppings = storeRepo.GetSizes(id);

            return toppings;
        }

        public List<BasicPizza> GetStorePresets(Guid id)
        {
            List<BasicPizza> presets = storeRepo.GetPresets(id);

            return presets;
        }
    }
}
