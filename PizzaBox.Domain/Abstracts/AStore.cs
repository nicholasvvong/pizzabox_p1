using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [XmlInclude(typeof(CaliforniaStore))]
    [XmlInclude(typeof(FreddyStore))]
    [XmlInclude(typeof(ChicagoStore))]
    [XmlInclude(typeof(NewYorkStore))]
    public class AStore
    {
        [Key]
        public Guid StoreID { get; set; } = Guid.NewGuid();
        public string Name{ get; protected set; } //Property
        public int MaxToppings { get; protected set; }
        public decimal MaxPrice { get; protected set; }
        public int MaxPizzas { get; protected set; }
        public IList<PresetPizza> PresetPizzas { get; protected set; }
        public IList<Topping> ToppingsList { get; protected set; }
        public IList<Size> SizeList { get; protected set; }
        public IList<Crust> CrustList { get; protected set; }

        protected AStore()
        {
            
        }

        protected virtual void AddTopping(decimal p, int i, string t, string n)
        {
            ToppingsList.Add(new Topping(this, p, i, t, n));
        }
        protected virtual void AddSize(decimal p, int i, string t, string n)
        {
            SizeList.Add(new Size(this, p, i, t, n));
        }
        protected virtual void AddCrust(decimal p, int i, string t, string n)
        {
            CrustList.Add(new Crust(this, p, i, t, n));
        }

        protected virtual void InitToppings(){}
        protected virtual void InitCrust(){}
        protected virtual void InitSize(){}
        protected virtual void InitPresetPizza(){}

        public override string ToString()
        {
            return Name;
        }
    }
}