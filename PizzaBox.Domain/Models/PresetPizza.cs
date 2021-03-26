using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class PresetPizza
    {
        [ForeignKey("StoreID")]
        public Guid StoreID { get; set; }
        [ForeignKey("PresetID")]
        public Guid PresetID { get; set; }
        
        public AStore store { get; set; }
        public BasicPizza BasicPizza { get; set; }
    }
}