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
        private readonly Mapper mapper = new Mapper();
        public StoreLogic(StoreRepository r)
        {
            storeRepo = r;
        }

        /// <summary>
        /// Gets all the stores in the database
        /// Returns it back to api as a name:Guid pair
        /// </summary>
        /// <returns>Dictionary<name, Guid></returns>
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

        /// <summary>
        /// Gets all the base item types from a store
        /// </summary>
        /// <returns>List of all the base item types</returns>
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

        /// <summary>
        /// Gets a store from Store ID
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>AStore object with all store information</returns>
        public AStore GetStore(Guid id)
        {
            AStore returnStore = storeRepo.FindStore(id);

            return returnStore;
        }

        /// <summary>
        /// Gets all the toppings a store offers based off store id
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>List of toppings</returns>
        public List<Topping> GetStoreToppings(Guid id)
        {
            List<Topping> toppings = storeRepo.GetToppings(id);

            return toppings;
        }

        /// <summary>
        /// Gets all the crusts a store offers based off store id
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>List of Crusts</returns>
        public List<Crust> GetStoreCrusts(Guid id)
        {
            List<Crust> toppings = storeRepo.GetCrusts(id);

            return toppings;
        }

        /// <summary>
        /// Gets all the sizes a store offers based off store id
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>List of Sizes</returns>
        public List<Size> GetStoreSizes(Guid id)
        {
            List<Size> toppings = storeRepo.GetSizes(id);

            return toppings;
        }

        /// <summary>
        /// Adds the new component into the database
        /// Creates an instance of the component based off the type
        /// Maps the RawNewComp to appropriate component
        /// </summary>
        /// <param name="obj">RawNewComp with all the info</param>
        /// <returns></returns>
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
                    Console.WriteLine("default");
                    return false;
                }
            }
            
        }

        /// <summary>
        /// Adds a new preset pizza to the databas
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the APizzaComponent from the database if it exists
        /// If it does not exist, create it and add it to the database
        /// Returns null if could not add to database
        /// </summary>
        /// <param name="compName">Name of component to try to add</param>
        /// <param name="baseType">BaseItemType of component</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates and adds a new topping to the database
        /// </summary>
        /// <param name="obj">RawComp User Input</param>
        /// <param name="pComp">PizzaComponent created or retrieved from database</param>
        /// <param name="curStore">Store to add new topping to</param>
        /// <returns>true/false if succesful</returns>
        public bool AddNewTopping(RawNewComp obj, APizzaComponent pComp, AStore curStore)
        {
            Topping newTopping = mapper.CompToTopping(pComp, obj, curStore);
            storeRepo.AddNewTopping(newTopping);
            return true;
        }

        /// <summary>
        /// Creates and adds a new crust to the database
        /// </summary>
        /// <param name="obj">RawComp User Input</param>
        /// <param name="pComp">PizzaComponent created or retrieved from database</param>
        /// <param name="curStore">Store to add new topping to</param>
        /// <returns>true/false if succesful</returns>
        public bool AddNewCrust(RawNewComp obj, APizzaComponent pComp, AStore curStore)
        {
            Crust newCrust = mapper.CompToCrust(pComp, obj, curStore);
            storeRepo.AddNewCrust(newCrust);
            return true;
        }

        /// <summary>
        /// Creates and adds a new size to the database
        /// </summary>
        /// <param name="obj">RawComp User Input</param>
        /// <param name="pComp">PizzaComponent created or retrieved from database</param>
        /// <param name="curStore">Store to add new topping to</param>
        /// <returns>true/false if succesful</returns>
        public bool AddNewSize(RawNewComp obj, APizzaComponent pComp, AStore curStore)
        {
            Size newSize = mapper.CompToSize(pComp, obj, curStore);
            storeRepo.AddNewSize(newSize);
            return true;
        }

        /// <summary>
        /// Gets all the preset pizzas a store offers based off store id
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>List of basicpizzas</returns>
        public List<BasicPizza> GetStorePresets(Guid id)
        {
            List<BasicPizza> presets = storeRepo.GetPresets(id);

            return presets;
        }

        /// <summary>
        /// Updates the updates with the new inventory and prices
        /// Uses a rawupdate object mapped from frontend
        /// </summary>
        /// <param name="obj">RawUpdate with lists of new info</param>
        /// <returns>true/false if successful or not</returns>
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
