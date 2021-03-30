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

        [HttpPost("login")]
        public string Login([FromBody] Customer obj)
        {
            Console.WriteLine("trying to login");
            Customer curCust = customerLogic.loginCheck(obj);
            return JsonSerializer.Serialize<Customer>(curCust);
        }

        [HttpPost("create")]
        public string Create([FromBody] Customer obj)
        {
            Customer cust = customerLogic.CreateCustomer(obj);
            return JsonSerializer.Serialize<Customer>(cust);
        }

        [HttpPost("init")]
        public void Init()
        {
            //customerLogic.LogicRepoGap();
        }

        // [HttpPost]
        // [ActionName("Create")]
        // public Customer Create([FromBody] string jsonString)
        // {
        //     Customer cust = JsonSerializer.Deserialize<Customer>(jsonString);
        //     cust.Fname = "bob";
        //     Console.WriteLine("InCreatingFunc2");
        //     return cust;
        // }
    }
}