using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public class AStore
    {
        [Key]
        public Guid StoreID { get; set; } = Guid.NewGuid();
        public string Name{ get; set; } //Property
        public int MaxToppings { get; set; }
        public decimal MaxPrice { get; set; }
        public int MaxPizzas { get; set; }
        public IList<BasicPizza> PresetPizzas { get; set; }
        public IList<Topping> ToppingsList { get; set; }
        public IList<Size> SizeList { get; set; }
        public IList<Crust> CrustList { get; set; }

        public AStore()
        {
            
        }

        protected virtual void AddTopping(decimal p, int i, string n, ItemType t)
        {
            ToppingsList.Add(new Topping(this, p, i, n, t));
        }
        protected virtual void AddSize(decimal p, int i, string n, ItemType t)
        {
            SizeList.Add(new Size(this, p, i, n, t));
        }
        protected virtual void AddCrust(decimal p, int i, string n, ItemType t)
        {
            CrustList.Add(new Crust(this, p, i, n, t));
        }

        public virtual void InitToppings(){}
        public virtual void InitCrust(){}
        public virtual void InitSize(){}
        public virtual void InitPresetPizza(){}

        public override string ToString()
        {
            return Name;
        }
    }
}