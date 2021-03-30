using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Order
    {   
        [Key]
        public Guid OrderID { get; set; }
        public Guid Cust { get; set; }
        public Guid Store { get; set; }
        public decimal CurTotal { get; protected set; }
        public DateTime OrderTime { get; set; }
        [NotMapped]
        public BasicPizza CurrentPizza { get; set; }
        public List<BasicPizza> Pizzas { get; protected set; }

        public Order()
        {
            Pizzas = new List<BasicPizza>();
            CurTotal = 0;
            OrderTime = DateTime.UtcNow;
        }

        public Order(Guid c, Guid s) : this()
        {
            Cust = c;
            Store = s;
        }
    }
}