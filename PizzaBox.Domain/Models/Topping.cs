using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [Table("Toppings")]
    public class Topping : APizzaComponent
    {
        [Column(Order = 0), ForeignKey("Comp")]
        public Guid ToppingID { get; set; }
        [Column(Order = 1), ForeignKey("Stores")]
        public Guid StoreID { get; set; }
        public decimal Price { get; protected set; }
        public int Inventory { get; protected set; }

        protected Topping()
        {
            
        }
        public Topping(AStore store, decimal p, int i, string n, ItemType t) : base(n, t)
        {
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
    }

    public class PreToppings : Topping
    {
        public int MyProperty { get; set; }
    }
}