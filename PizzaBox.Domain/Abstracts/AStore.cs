using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [Table("Stores")]
    public class AStore
    {
        [Key]
        public Guid StoreID { get; set; } = Guid.NewGuid();
        public string Name{ get; set; } //Property
        public int MaxToppings { get; set; }
        public decimal MaxPrice { get; set; }
        public int MaxPizzas { get; set; }
        public List<BasicPizza> PresetPizzas { get; set; }
        public List<Topping> ToppingsList { get; set; }
        public List<Size> SizeList { get; set; }
        public List<Crust> CrustList { get; set; }

        public AStore()
        {
            PresetPizzas = new List<BasicPizza>();
            ToppingsList = new List<Topping>();
            SizeList = new List<Size>();
            CrustList = new List<Crust>();
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

        protected virtual void AddTopping(decimal p, int i, APizzaComponent apc)
        {
            ToppingsList.Add(new Topping(this, p, i, apc));
        }
        protected virtual void AddSize(decimal p, int i, APizzaComponent apc)
        {
            SizeList.Add(new Size(this, p, i, apc));
        }
        protected virtual void AddCrust(decimal p, int i, APizzaComponent apc)
        {
            CrustList.Add(new Crust(this, p, i, apc));
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