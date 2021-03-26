using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class PresetPizza : BasicPizza
    {
        [ForeignKey("PresetID")]
        public Guid BasicPizzaID { get; set; }
        public AStore store { get; set; }

        public PresetPizza() : base()
        {
            
        }
        public PresetPizza(AStore s) : base()
        {
            store = s;
        }
    }
}