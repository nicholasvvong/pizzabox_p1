using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizzaComponent
    {
        [Key]
        public Guid CompID { get; set; } = new Guid();
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public int Inventory { get; protected set; }
        protected APizzaComponent()
        {

        }

        public APizzaComponent(string type, decimal p)
        {
            FactoryMethod(type, p);
        }

        private void FactoryMethod(string type, decimal p)
        {
            AddName(type);
            AddPrice(p);
        }

        protected abstract void AddName(string type);
        protected abstract void AddPrice(decimal p);
        protected abstract void AddInventory(int p);
    }
}