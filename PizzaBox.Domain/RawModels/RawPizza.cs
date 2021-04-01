using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class RawPizza
    {
        public string Crust { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public List<string> Toppings { get; set; }
    }
}