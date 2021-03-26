using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Abstracts
{
    public class APizzaComponent
    {
        [Key]
        public Guid CompID { get; set; } = new Guid();
        public string Name { get; set; }
        public string Type { get; set; }
        public APizzaComponent()
        {

        }

        public APizzaComponent(string n, string t)
        {
            FactoryMethod(n, t);
        }

        private void FactoryMethod(string n, string t)
        {
            AddName(n);
            AddType(t);
        }

        protected virtual void AddName(string n) 
        {
            Name = n;
        }
        protected virtual void AddType(string t)
        {
            Type = t;
        }
    }
}