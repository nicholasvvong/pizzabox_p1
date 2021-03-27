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

        [HttpGet("{id}")]
        public AStore Get(Guid id)
        {
            AStore store = storeLogic.GetStoreObject(id);

            return store;
        }

        [HttpGet]
        public Dictionary<string, Guid> Get()
        {
            Dictionary<string, Guid> stores = storeLogic.GetStoresStrings();

            return stores;
        }
    }
}