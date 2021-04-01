using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class RawOrderHistory
    {
        public List<string> StoreName { get; set; }
        public List<decimal> Totals { get; set; }
        public List<string> jsonPizzaOrders { get; set; }
        public List<DateTime> OrderTimes { get; set; }
    }
}