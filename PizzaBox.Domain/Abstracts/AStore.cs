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
        public Guid StoreID { get; set; } = new Guid();
        public string Name{ get; protected set; } //Property
        public int MaxToppings { get; protected set; }
        public int MaxPrice { get; protected set; }
        public int MaxPizzas { get; protected set; }
        public ICollection<PresetPizza> PresetPizzas { get; protected set; }
        public ICollection<Topping> ToppingsList { get; protected set; }
        public ICollection<Size> SizeList { get; protected set; }
        public ICollection<Crust> CrustList { get; protected set; }

        protected AStore()
        {
            
        }

        protected virtual void AddTopping(string type, decimal price)
        {
            ToppingsList.Add(new Topping(type, price));
        }
        protected virtual void AddSize(string type, decimal price)
        {
            SizeList.Add(new Size(type, price));
        }
        protected virtual void AddCrust(string type, decimal price)
        {
            CrustList.Add(new Crust(type, price));
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