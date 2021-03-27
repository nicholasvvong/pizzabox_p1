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
            PresetPizzas = new List<BasicPizza>();
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

        public override void InitToppings()
        {
            ItemType toppings = new ItemType("toppings");
            AddTopping(0.66m, 100, "beef", toppings);
            AddTopping(0.75m, 100, "chicken", toppings);
            AddTopping(0.50m, 100, "ham", toppings);
            AddTopping(0.60m, 100, "mushroom", toppings);
            AddTopping(0.30m, 100, "olive", toppings);
            AddTopping(0.40m, 100, "peppers", toppings);
            AddTopping(0.50m, 100, "pepporoni", toppings);
            AddTopping(0.35m, 100, "pineapple", toppings);
            AddTopping(0.45m, 100, "salami", toppings);
            AddTopping (0.55m, 100, "sausage", toppings);
        }
        public override void InitSize()
        {
            ItemType size = new ItemType("size");
            AddSize(3.0m, 100, "small", size);
            AddSize(4.0m, 100, "medium", size);
            AddSize(5.0m, 100, "large", size);
            AddSize (6.0m, 100, "extra large", size);
        }
        public override void InitCrust()
        {
            ItemType crust = new ItemType("crust");
            AddCrust(1.0m, 100, "regular", crust);
            AddCrust(1.5m, 100, "hand-tossed", crust);
            AddCrust(1.0m, 100, "thin", crust);
        }
        
        public override void InitPresetPizza()
        {
            /*Meat*/
            BasicPizza tempP = new BasicPizza();
            tempP.Type = "Meat Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[0]);
            tempP.AddTopping(ToppingsList[1]);
            tempP.AddTopping(ToppingsList[2]);
            tempP.AddTopping(ToppingsList[6]);
            tempP.AddTopping(ToppingsList[8]);
            tempP.CalculatePrice();
            // PresetPizza presetP = new PresetPizza();
            // presetP.BasicPizza = tempP;
            // presetP.StoreID = this.StoreID;
            PresetPizzas.Add(tempP);
            /*Hawaiian*/
            tempP = new BasicPizza();
            tempP.Type = "Hawaiian Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[2]);
            tempP.AddTopping(ToppingsList[5]);
            tempP.AddTopping(ToppingsList[7]);
            tempP.CalculatePrice();
            // presetP = new PresetPizza();
            // presetP.BasicPizza = tempP;
            // presetP.StoreID = this.StoreID;
            PresetPizzas.Add(tempP);
        }
        
    }
}