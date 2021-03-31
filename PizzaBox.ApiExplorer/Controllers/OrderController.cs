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
        private readonly OrderLogic orderLogic;
        public OrderController(OrderLogic sL)
        {
            orderLogic = sL;
        }

        [HttpGet("history/{id}")]
        public ActionResult<RawOrderHistory> OrderHistory(Guid id)
        {
            RawOrderHistory orderHistory;
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Invalid Guid format");
            }
            else
            {
                orderHistory = orderLogic.GetOrderHistory(id);
            }

            return orderHistory;
        }
        
        [HttpPost("submit")]
        public ActionResult<Order> SubmitOrder([FromBody] RawOrder obj)
        {
            Order newOrder;
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Failed to create models");
            }
            else
            {
                newOrder = orderLogic.CreateOrder(obj);
            }

            return newOrder;
        }
    }
}