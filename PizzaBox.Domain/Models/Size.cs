using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public class Size
    {
        public Guid SizeID { get; set; } = Guid.NewGuid();
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public AStore Store { get; set; }
        public APizzaComponent PizzaType { get; set; }
        protected Size()
        {
            
        }
        public Size(AStore store, decimal p, int i, string n, ItemType t)
        {
            Store = store;
            Price = p;
            Inventory = i;
            PizzaType = new APizzaComponent(n, t);
        }

        public Size(AStore store, decimal p, int i, APizzaComponent apc)
        {
            Store = store;
            Price = p;
            Inventory = i;
            PizzaType = apc;
        }

        protected void AddPrice(decimal p)
        {
            Price = p;
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