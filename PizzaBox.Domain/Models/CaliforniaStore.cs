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
            AddTopping(0.66m, 100, "beef", new ItemType("topping"));
            AddTopping(0.66m, 100, "chicken", new ItemType("topping"));
            AddTopping(0.66m, 100, "ham", new ItemType("topping"));
            AddTopping(0.66m, 100, "mushroom", new ItemType("topping"));
            AddTopping(0.66m, 100, "olive", new ItemType("topping"));
            AddTopping(0.66m, 100, "peppers", new ItemType("topping"));
            AddTopping(0.66m, 100, "pepporoni", new ItemType("topping"));
            AddTopping(0.66m, 100, "pineapple", new ItemType("topping"));
            AddTopping(0.66m, 100, "salami", new ItemType("topping"));
            AddTopping (0.66m, 100, "sausage", new ItemType("topping"));
        }
        protected override void InitSize()
        {
            AddSize(3.0m, 100, "small", new ItemType("size"));
            AddSize(4.0m, 100, "medium", new ItemType("size"));
            AddSize(5.0m, 100, "large", new ItemType("size"));
            AddSize (6.0m, 100, "extra large", new ItemType("size"));
        }
        protected override void InitCrust()
        {
            AddCrust(1.0m, 100, "regular", new ItemType("crust"));
            AddCrust(1.5m, 100, "hand-tossed", new ItemType("crust"));
            AddCrust(1.0m, 100, "thin", new ItemType("crust"));
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