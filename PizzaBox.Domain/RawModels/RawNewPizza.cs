using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class RawNewPizza
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public RawComp Crust { get; set; }
        public List<RawComp> AllToppings { get; set; }
    }
}