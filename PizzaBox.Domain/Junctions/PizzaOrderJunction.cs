using System;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Junctions
{
    public class PizzaOrderJunction
    {
        [ForeignKey("PresetID")]
        public Guid PresetPizzaID { get; set; }
        [ForeignKey("OrderID")]
        public Guid OrderID { get; set; }

        public virtual PresetPizza PresetPizza { get; set; }
        public virtual Order Order { get; set; }
    }
}