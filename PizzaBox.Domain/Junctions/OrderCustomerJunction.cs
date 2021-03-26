using System;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Junctions
{
    public class OrderCustomerJunction
    {
        [ForeignKey("OrderID")]
        public Guid OrderID { get; set; }
        [ForeignKey("CustomerID")]
        public Guid CustomerID { get; set; }

        public virtual Order Order { get; set; }
        public virtual Customer Customer { get; set; }
        
    }
}