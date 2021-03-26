using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [Table("Sizes")]
    public class Size : APizzaComponent
    {
        [Column(Order = 0), ForeignKey("CompID")]
        public Guid SizeID { get; set; }
        [Column(Order = 1), ForeignKey("StoreID")]
        public Guid StoreID { get; set; }
        public decimal Price { get; protected set; }
        public int Inventory { get; protected set; }
        protected Size()
        {
            
        }
        public Size(AStore store, decimal p, int i, string n, ItemType t) : base(n, t)
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
}