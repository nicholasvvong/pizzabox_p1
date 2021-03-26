using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [Table("Toppings")]
    public class Topping : APizzaComponent
    {
        public decimal Price { get; protected set; }
        public int Inventory { get; protected set; }
        public AStore Store { get; set; }

        protected Topping()
        {
            
        }
        public Topping(AStore store, decimal p, int i, string n, ItemType t) : base(n, t)
        {
            Store = store;
            Price = p;
            Inventory = i;
        }

        protected void AddPrice(decimal p)
        {
            Price = p;
        }
        protected override void AddName(string n)
        {
            Name = n;
        }
        protected override void AddType(ItemType t)
        {
            IType = t;
        }
        protected void SetInventory(int p)
        {
            Inventory = p;
        }
        protected void AddInventory(int p)
        {
            Inventory += p;
        }
        protected void DecreaseInventory(int p)
        {
            Inventory -= p;
        }
    }
}