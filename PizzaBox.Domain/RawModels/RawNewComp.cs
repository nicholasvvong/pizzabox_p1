using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class RawNewComp
    {
        public Guid ID { get; set; }
        public Guid ItemID { get; set; }
        public string ItemName { get; set; }
        public string CompName { get; set; }
        public decimal Price { get; set; }
    }
}