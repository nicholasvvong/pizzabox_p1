using System;
using System.Collections.Generic;
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
        public IEnumerable<AStore> Get()
        {
            List<AStore> stores = storeLogic.GetStores();
            stores.Add(new CaliforniaStore());
            stores.Add(new NewYorkStore());
            return stores;
        }
    }
}