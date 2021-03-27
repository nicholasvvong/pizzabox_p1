using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class PresetPizza
    {
        public Guid BasicPizzaID { get; set; }
        public BasicPizza BasicPizza { get; set; }
        public Guid ToppingID { get; set; }
        public Topping Topping { get; set; }
    }
}