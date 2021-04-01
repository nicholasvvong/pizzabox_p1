using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Logic.Interfaces;
using PizzaBox.Repository;

namespace PizzaBox.Logic
{
    public class StoreLogic : IStoreLogic
    {
        private readonly StoreRepository storeRepo;
        private readonly Mapper mapper = new Mapper();
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

        public List<ItemType> GetItemTypes()
        {
            List<ItemType> liItems = storeRepo.GetItemTypes();

            if(liItems.Count <= 0)
            {
                return null;
            }
            else
            {
                return liItems;
            }
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

        public bool AddNewComp(RawNewComp obj)
        {
            AStore curStore = storeRepo.FindStore(obj.ID);
            if(curStore is null)
            {
                return false;
            }
            ItemType baseType = storeRepo.GetBaseItem(obj.ItemID);
            if(baseType is null)
            {
                return false;
            }
            APizzaComponent pComp = GetPizzaComponent(obj.CompName, baseType);
            if(pComp is null)
            {
                return false;
            }
            switch(obj.ItemName.ToLower())
            {
                case "crust":
                {
                    return AddNewCrust(obj, pComp, curStore);
                }
                case "size":
                {
                    return AddNewSize(obj, pComp, curStore);
                }
                case "toppings":
                {
                    return AddNewTopping(obj, pComp, curStore);
                }
                default:
                {
                    return false;
                }
            }
            
        }

        public bool AddNewPizza(RawNewPizza obj)
        {
            AStore curStore = storeRepo.FindStore(obj.ID);
            if(curStore is null)
            {
                return false;
            }
            Crust newCrust = storeRepo.GetCrustByID(obj.Crust.ID);
            if(newCrust is null)
            {
                return false;
            }

            List<Topping> toppings = new List<Topping>();
            foreach(RawComp rc in obj.AllToppings)
            {
                Topping t = storeRepo.GetToppingByID(rc.ID);
                if(t is null)
                {
                    return false;
                }
                toppings.Add(t);
            }
            BasicPizza newPizza = mapper.RawToBasicPizzaMapper(obj, newCrust, toppings);

            if(!storeRepo.AddPizzaToStore(obj.ID, newPizza))
            {
                return false;
            }
            return true;
        }

        public APizzaComponent GetPizzaComponent(string compName, ItemType baseType)
        {
            APizzaComponent pComp = storeRepo.GetPizzaComp(compName);
            if(pComp is null)
            {
                APizzaComponent newComp = mapper.ItemToCompMapper(compName, baseType);

                pComp = storeRepo.AddPizzaComp(newComp);
                if(pComp is null)
                {
                    return null;
                }
            }
            return pComp;
        }

        public bool AddNewTopping(RawNewComp obj, APizzaComponent pComp, AStore curStore)
        {
            Topping newTopping = mapper.CompToTopping(pComp, obj, curStore);
            storeRepo.AddNewTopping(newTopping);
            return true;
        }

        public bool AddNewCrust(RawNewComp obj, APizzaComponent pComp, AStore curStore)
        {
            Crust newCrust = mapper.CompToCrust(pComp, obj, curStore);
            storeRepo.AddNewCrust(newCrust);
            return true;
        }

        public bool AddNewSize(RawNewComp obj, APizzaComponent pComp, AStore curStore)
        {
            Size newSize = mapper.CompToSize(pComp, obj, curStore);
            storeRepo.AddNewSize(newSize);
            return true;
        }

        public List<BasicPizza> GetStorePresets(Guid id)
        {
            List<BasicPizza> presets = storeRepo.GetPresets(id);

            return presets;
        }

        public bool UpdateDatabase(RawUpdate obj)
        {
            foreach(RawComp rc in obj.CrustList)
            {
                storeRepo.UpdateCrustInventory(obj.ID, rc.Name, rc.Inventory);
                storeRepo.UpdateCrustPrice(obj.ID, rc.Name, rc.Price);
            }
            foreach(RawComp rc in obj.SizeList)
            {
                storeRepo.UpdateSizeInventory(obj.ID, rc.Name, rc.Inventory);
                storeRepo.UpdateSizePrice(obj.ID, rc.Name, rc.Price);
            }
            foreach(RawComp rc in obj.ToppingList)
            {
                storeRepo.UpdateToppingInventory(obj.ID, rc.Name, rc.Inventory);
                storeRepo.UpdateToppingPrice(obj.ID, rc.Name, rc.Price);
            }

            return true;
        }
    }
}
