using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public class Crust
    {
        public Guid CrustID { get; set; } = Guid.NewGuid();
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public bool CheeseStuffed { get; set; }
        public decimal StuffedPrice { get; private set; }
        public APizzaComponent PizzaType { get; set; }

        public AStore Store { get; set; }

        protected Crust()
        {

        }
        public Crust(AStore store, decimal p, int i, string n, ItemType t)
        {
            CheeseStuffed = false;
            StuffedPrice = 1.50m;
            Store = store;
            Price = p;
            Inventory = i;
            PizzaType = new APizzaComponent(n, t);
        }
        public Crust(AStore store, decimal p, int i, APizzaComponent apc)
        {
            CheeseStuffed = false;
            StuffedPrice = 1.50m;
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

        protected void ChangeStuffedCrust()
        {
            if(CheeseStuffed)
                CheeseStuffed = false;
            else
                CheeseStuffed = true;
        }
    }
}