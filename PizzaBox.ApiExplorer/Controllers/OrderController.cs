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

        [HttpGet("history/customer/{id}")]
        public ActionResult<RawOrderHistory> CustomerOrderHistory(Guid id)
        {
            RawOrderHistory orderHistory;
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Invalid Guid format");
            }
            else
            {
                orderHistory = orderLogic.GetCustomerOrderHistory(id);
            }

            return orderHistory;
        }

        [HttpGet("history/store/{id}")]
        public ActionResult<RawOrderHistory> StoreOrderHistory(Guid id)
        {
            RawOrderHistory orderHistory;
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Invalid Guid format");
            }
            else
            {
                orderHistory = orderLogic.GetStoreOrderHistory(id);
            }
            if(orderHistory is null) {
                return StatusCode(500, "Could not find store or customers in database");
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