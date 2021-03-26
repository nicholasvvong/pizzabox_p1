using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CaliforniaStore : AStore
    {
        public CaliforniaStore()
        {
            Name = "CPK";
            PresetPizzas = new List<PresetPizza>();
            ToppingsList = new List<Topping>();
            SizeList = new List<Size>();
            CrustList = new List<Crust>();
            MaxToppings = 5;
            MaxPizzas = 50;
            MaxPrice = 250.0m;
            
            InitToppings();
            InitSize();
            InitCrust();  
            InitPresetPizza();
            
        }

        protected override void InitToppings()
        {
            AddTopping(0.66m, 100, "topping", "beef");
            AddTopping(0.66m, 100, "topping", "chicken");
            AddTopping(0.66m, 100, "topping", "ham");
            AddTopping(0.66m, 100, "topping", "mushroom");
            AddTopping(0.66m, 100, "topping", "olive");
            AddTopping(0.66m, 100, "topping", "peppers");
            AddTopping(0.66m, 100, "topping", "pepporoni");
            AddTopping(0.66m, 100, "topping", "pineapple");
            AddTopping(0.66m, 100, "topping", "salami");
            AddTopping (0.66m, 100, "topping", "sausage");
        }
        protected override void InitSize()
        {
            AddSize(3.0m, 100, "size", "small");
            AddSize(4.0m, 100, "size", "medium");
            AddSize(5.0m, 100, "size", "large");
            AddSize (6.0m, 100, "size", "extra large");
        }
        protected override void InitCrust()
        {
            AddCrust(1.0m, 100, "crust", "regular");
            AddCrust(1.5m, 100, "crust", "hand-tossed");
            AddCrust(1.0m, 100, "crust", "thin");
        }
        
        protected override void InitPresetPizza()
        {
            /*Meat*/
            PresetPizza tempP = new PresetPizza(this);
            tempP.Type = "Meat Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[0]);
            tempP.AddTopping(ToppingsList[1]);
            tempP.AddTopping(ToppingsList[2]);
            tempP.AddTopping(ToppingsList[6]);
            tempP.AddTopping(ToppingsList[8]);
            tempP.CalculatePrice();
            PresetPizzas.Add(tempP);
            /*Hawaiian*/
            tempP = new PresetPizza(this);
            tempP.Type = "Hawaiian Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[2]);
            tempP.AddTopping(ToppingsList[5]);
            tempP.AddTopping(ToppingsList[7]);
            tempP.CalculatePrice();
            PresetPizzas.Add(tempP);
        }
        
    }
}