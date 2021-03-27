using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [Table("Comps")]
    public class APizzaComponent
    {
        [Key]
        public Guid CompID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ItemType IType { get; set; }
        
        public APizzaComponent()
        {

        }

        public APizzaComponent(string n, ItemType t)
        {
            FactoryMethod(n, t);
        }

        private void FactoryMethod(string n, ItemType t)
        {
            AddName(n);
            AddType(t);
        }

        protected virtual void AddName(string n) 
        {
            Name = n;
        }
        protected virtual void AddType(ItemType t)
        {
            IType = t;
        }
    }
}