using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public class Topping
    {
        public Guid ToppingID { get; set; } = Guid.NewGuid();
        public decimal Price { get; protected set; }
        public int Inventory { get; protected set; }
        public AStore Store { get; set; }
        public APizzaComponent PizzaType { get; set; }

        public ICollection<BasicPizza>  Pizzas { get; set; }
        public ICollection<PresetPizza> PresetPizzas { get; set; }

        protected Topping()
        {
            
        }

        public Topping(AStore store, decimal p, int i, string n, ItemType t)
        {
            Store = store;
            Price = p;
            Inventory = i;
            PizzaType = new APizzaComponent(n, t);
        }

        public Topping(AStore store, decimal p, int i, APizzaComponent apc)
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