using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Microsoft.Data.SqlClient;

namespace PizzaBox.Repository
{
    public class OrderRepository
    {
        private readonly OrderContext context;

        public OrderRepository(OrderContext c)
        {
            context = c;
        }
    }
}