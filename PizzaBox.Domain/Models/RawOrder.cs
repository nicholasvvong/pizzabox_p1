using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class RawOrder
    {
        public List<RawPizza> PizzaList { get; set; }
        public Guid StoreID { get; set; }
        public Guid CustomerID { get; set; }
        public decimal Total { get; set; }
    }
}