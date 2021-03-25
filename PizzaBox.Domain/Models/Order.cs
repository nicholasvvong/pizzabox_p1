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
        public Customer Cust { get; set; }
        public AStore Store { get; set; }
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

        public Order(Customer c, AStore s) : this()
        {
            Cust = c;
            Store = s;
        }
    }
}