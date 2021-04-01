using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class RawComp
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
    }
}