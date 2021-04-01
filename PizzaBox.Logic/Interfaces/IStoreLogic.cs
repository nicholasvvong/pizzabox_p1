using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Logic.Interfaces
{
    interface IStoreLogic
    {
        /// <summary>
        /// Gets all the preset pizzas a store offers based off store id
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>List of basicpizzas</returns>
        List<BasicPizza> GetStorePresets(Guid id);

        /// <summary>
        /// Updates the updates with the new inventory and prices
        /// Uses a rawupdate object mapped from frontend
        /// </summary>
        /// <param name="obj">RawUpdate with lists of new info</param>
        /// <returns>true/false if successful or not</returns>
        bool UpdateDatabase(RawUpdate obj);

        /// <summary>
        /// Creates and adds a new size to the database
        /// </summary>
        /// <param name="obj">RawComp User Input</param>
        /// <param name="pComp">PizzaComponent created or retrieved from database</param>
        /// <param name="curStore">Store to add new topping to</param>
        /// <returns>true/false if succesful</returns>
        bool AddNewSize(RawNewComp obj, APizzaComponent pComp, AStore curStore);

        /// <summary>
        /// Creates and adds a new crust to the database
        /// </summary>
        /// <param name="obj">RawComp User Input</param>
        /// <param name="pComp">PizzaComponent created or retrieved from database</param>
        /// <param name="curStore">Store to add new topping to</param>
        /// <returns>true/false if succesful</returns>
        bool AddNewCrust(RawNewComp obj, APizzaComponent pComp, AStore curStore);

        /// <summary>
        /// Creates and adds a new topping to the database
        /// </summary>
        /// <param name="obj">RawComp User Input</param>
        /// <param name="pComp">PizzaComponent created or retrieved from database</param>
        /// <param name="curStore">Store to add new topping to</param>
        /// <returns>true/false if succesful</returns>
        bool AddNewTopping(RawNewComp obj, APizzaComponent pComp, AStore curStore);

        /// <summary>
        /// Gets the APizzaComponent from the database if it exists
        /// If it does not exist, create it and add it to the database
        /// Returns null if could not add to database
        /// </summary>
        /// <param name="compName">Name of component to try to add</param>
        /// <param name="baseType">BaseItemType of component</param>
        /// <returns></returns>
        APizzaComponent GetPizzaComponent(string compName, ItemType baseType);

        /// <summary>
        /// Adds a new preset pizza to the databas
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool AddNewPizza(RawNewPizza obj);

        /// <summary>
        /// Adds the new component into the database
        /// Creates an instance of the component based off the type
        /// Maps the RawNewComp to appropriate component
        /// </summary>
        /// <param name="obj">RawNewComp with all the info</param>
        /// <returns></returns>
        bool AddNewComp(RawNewComp obj);

        /// <summary>
        /// Gets all the sizes a store offers based off store id
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>List of Sizes</returns>
        List<Size> GetStoreSizes(Guid id);

        /// <summary>
        /// Gets all the crusts a store offers based off store id
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>List of Crusts</returns>
        List<Crust> GetStoreCrusts(Guid id);

        /// <summary>
        /// Gets all the toppings a store offers based off store id
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>List of toppings</returns>
        List<Topping> GetStoreToppings(Guid id);

        /// <summary>
        /// Gets a store from Store ID
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>AStore object with all store information</returns>
        AStore GetStore(Guid id);

        /// <summary>
        /// Gets all the base item types from a store
        /// </summary>
        /// <returns>List of all the base item types</returns>
        List<ItemType> GetItemTypes();

        /// <summary>
        /// Gets all the stores in the database
        /// Returns it back to api as a name:Guid pair
        /// </summary>
        /// <returns>Dictionary&lt;name, Guid></returns>
        Dictionary<string, Guid> GetStoresStrings();
    }
}