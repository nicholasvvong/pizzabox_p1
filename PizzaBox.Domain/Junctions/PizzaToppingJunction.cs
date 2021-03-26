using System;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Junctions
{
    public class PizzaToppingJunction
    {
        [ForeignKey("PresetID")]
        public Guid PresetPizzaID { get; set; }
        [ForeignKey("ToppingID")]
        public Guid ToppingID { get; set; }

        public virtual PresetPizza PresetPizza { get; set; }
        public virtual Topping Topping { get; set; }
    }
}