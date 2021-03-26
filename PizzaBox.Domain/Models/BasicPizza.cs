using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    public class BasicPizza
    {
        public Guid PresetID { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        public decimal PizzaPrice { get; protected set; }
        public List<Topping> Toppings { get; set; }
        public Crust Crust { get; set; }
        public Size Size{ get; set; }

        public BasicPizza()
        {
            FactoryMethod();
        }

        private void FactoryMethod()
        {
            PizzaPrice = 0;
            Toppings = new List<Topping>();
        }

        public void AddCrust(Crust c)
        {
            Crust = c;
        }
        public void AddSize(Size s)
        {
            Size = s;
        }
        public void AddTopping(Topping t)
        {
            Toppings.Add(t);
        }
        public virtual decimal CalculatePrice()
        {
            PizzaPrice = 0;
            if(Crust != null)
            {
                //PizzaPrice += Crust.Price;
            
                if(Crust.CheeseStuffed)
                    PizzaPrice += Crust.StuffedPrice;
            }

            if(Size != null)
            {
                //PizzaPrice += Size.Price;
            }
            if(Toppings != null)
            {
                foreach(Topping t in Toppings)
                {
                    //PizzaPrice += t.Price;
                }
            }

            return PizzaPrice;
        }
    }
}