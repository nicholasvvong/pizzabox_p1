using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [Table("Crusts")]
    public class Crust : APizzaComponent
    {
        [Column(Order = 0), ForeignKey("CompID")]
        public Guid CrustID { get; set; }
        [Column(Order = 1), ForeignKey("StoreID")]
        public Guid StoreID { get; set; }
        public decimal Price { get; protected set; }
        public int Inventory { get; protected set; }
        public bool CheeseStuffed { get; set; }
        public decimal StuffedPrice { get; private set; }
        protected Crust()
        {

        }
        public Crust(AStore store, decimal p, int i, string n, ItemType t) : base(n, t)
        {
            CheeseStuffed = false;
            StuffedPrice = 1.50m;
            StoreID = store.StoreID;
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

        protected void ChangeStuffedCrust()
        {
            if(CheeseStuffed)
                CheeseStuffed = false;
            else
                CheeseStuffed = true;
        }
    }
}