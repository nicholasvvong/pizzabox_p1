using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Logic;

namespace PizzaBox.ApiExplorer
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly StoreLogic storeLogic;
        public StoreController(StoreLogic sL)
        {
            storeLogic = sL;
        }

        /// <summary>
        /// Gets the base item types of pizza components
        /// </summary>
        /// <returns>Base ItemTypes</returns>
        [HttpGet("ItemTypes")]
        public List<ItemType> GetItemTypes()
        {
            List<ItemType> itemTypes = storeLogic.GetItemTypes();

            return itemTypes;
        }

        /// <summary>
        /// Gets all the store names and their Guid
        /// </summary>
        /// <returns>Dictionary<Store name, Store id></returns>
        [HttpGet]
        public Dictionary<string, Guid> Get()
        {
            Dictionary<string, Guid> stores = storeLogic.GetStoresStrings();

            return stores;
        }

        /// <summary>
        /// Gets all information about a store using store ID
        /// Information includes toppings, crusts, sizes, presets
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>AStore</returns>
        [HttpPost("StoreInfo")]
        public AStore Store([FromBody] Guid id)
        {
            AStore store = storeLogic.GetStore(id);

            return store;
        }

        /// <summary>
        /// Gets all of a store's toppings using store ID
        /// </summary>
        /// <param name="id">store ID</param>
        /// <returns>List of Toppings</returns>
        [HttpPost("Toppings")]
        public List<Topping> StoreToppings([FromBody] Guid id)
        {
            List<Topping> toppings = storeLogic.GetStoreToppings(id);

            return toppings;
        }

        /// <summary>
        /// Gets all the crusts a store offers using store ID
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>List of Crusts</returns>
        [HttpPost("Crusts")]
        public List<Crust> StoreCrust([FromBody] Guid id)
        {
            List<Crust> crusts = storeLogic.GetStoreCrusts(id);

            return crusts;
        }

        /// <summary>
        /// Gets all the sizes a store offers using store ID
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>List of Sizes</returns>
        [HttpPost("Sizes")]
        public List<Size> StoreSize([FromBody] Guid id)
        {
            List<Size> sizes = storeLogic.GetStoreSizes(id);

            return sizes;
        }  

        /// <summary>
        /// Gets all the preset pizzas a store offers using store ID
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>List of Preset Pizzas</returns>
        [HttpPost("Presets")]
        public List<BasicPizza> StorePresets([FromBody] Guid id)
        {
            List<BasicPizza> presetP = storeLogic.GetStorePresets(id);
            foreach(BasicPizza bp in presetP)
            {
                bp.CalculatePrice();
            }
            return presetP;
        }

        /// <summary>
        /// Updates a store's inventory and price based off new information
        /// </summary>
        /// <param name="obj">RawUpdate with everything to be updated</param>
        /// <returns>StatusCode whether operation was successful or not</returns>
        [HttpPost("Update/{id}")]
        public ActionResult<bool> UpdateInventoryPrice(RawUpdate obj)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Failed to create models");
            }
            else
            {
                if(storeLogic.UpdateDatabase(obj))
                {
                    return StatusCode(201, "Everything updated successfully");
                }
                else
                {
                    return StatusCode(500, "One or more items may have failed to update.");
                }
            }
        }

        /// <summary>
        /// Adds a new component to a store
        /// </summary>
        /// <param name="obj">RawNewComp containing storeID and new component information</param>
        /// <returns>StatusCode whether operation was successful or not</returns>
        [HttpPost("Add/Comp")]
        public ActionResult<bool> AddNewComp([FromBody] RawNewComp obj)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Failed to create models");
            }
            else
            {
                if(storeLogic.AddNewComp(obj))
                {
                    return StatusCode(201, "Successfully added new pizza component");
                }
                else
                {
                    return StatusCode(500, "Failed to add new pizza component`");
                }
            }
        }

        /// <summary>
        /// Adds a new preset pizza to the store
        /// </summary>
        /// <param name="obj">RawNewPizza containing storeID and new pizza information</param>
        /// <returns>StatusCode whether operation was successful or not</returns>
        [HttpPost("Add/Pizza")]
        public ActionResult<bool> AddNewPizza([FromBody] RawNewPizza obj)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Failed to create models");
            }
            else
            {
                if(storeLogic.AddNewPizza(obj))
                {
                    return StatusCode(201, "Failed to create models");
                }
                else
                {
                    return StatusCode(500, "Failed to add pizza");
                }
            }
        }
    }
}