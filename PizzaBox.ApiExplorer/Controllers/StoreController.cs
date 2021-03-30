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

        [HttpGet]
        public Dictionary<string, Guid> Get()
        {
            Dictionary<string, Guid> stores = storeLogic.GetStoresStrings();

            return stores;
        }

        [HttpPost("StoreInfo")]
        public AStore Store([FromBody] Guid id)
        {
            AStore store = storeLogic.GetStore(id);

            return store;
        }

        [HttpPost("Toppings")]
        public List<Topping> StoreToppings([FromBody] Guid id)
        {
            List<Topping> toppings = storeLogic.GetStoreToppings(id);

            return toppings;
        }

        [HttpPost("Crusts")]
        public List<Crust> StoreCrust([FromBody] Guid id)
        {
            List<Crust> crusts = storeLogic.GetStoreCrusts(id);

            return crusts;
        }

        [HttpPost("Sizes")]
        public List<Size> StoreSize([FromBody] Guid id)
        {
            List<Size> sizes = storeLogic.GetStoreSizes(id);

            return sizes;
        }

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
    }
}