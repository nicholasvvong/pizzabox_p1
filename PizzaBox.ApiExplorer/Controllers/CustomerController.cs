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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerLogic customerLogic;
        public CustomerController(CustomerLogic sL)
        {
            customerLogic = sL;
        }
        [HttpGet]
        public Customer Get()
        {
            Customer curCust = new Customer();
            return curCust;
        }

        /// <summary>
        /// Attempts to login a user based off user input
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] RawCustomer obj)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Failed to create models");
            }
            else
            {
                Customer curCust = customerLogic.LoginCheck(obj);
                if(curCust is null) {
                    return StatusCode(450, "Invalid information");
                }
                return JsonSerializer.Serialize<Customer>(curCust);
            }
            
        }

        /// <summary>
        /// Creates a new customer based off customer input
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public ActionResult<string> Create([FromBody] RawCustomer obj)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Failed to create models");
            }
            else
            {
                Customer cust = customerLogic.CreateCustomer(obj);
                if(cust is null)
                {
                    return StatusCode(450, "Failed to create. Possibly already exists");
                }
                return JsonSerializer.Serialize<Customer>(cust);
            }
            //return StatusCode(200, "Success or nothing happened");
        }

        /// <summary>
        /// Meant to do a call to seed the database with customers
        /// </summary>
        [HttpPost("init")]
        public ActionResult Init()
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Failed to create models");
            }
            else
            {
                //customerLogic.InitStoreOwners();
            }

            return StatusCode(200, "Success or nothing happened");
        }
    }
}