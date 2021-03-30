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
    public class OrderController : ControllerBase
    {
        private readonly ORderLogic orderLogic;
        public CustomerController(OrderLogic sL)
        {
            orderLogic = sL;
        }
        
    
    }
}