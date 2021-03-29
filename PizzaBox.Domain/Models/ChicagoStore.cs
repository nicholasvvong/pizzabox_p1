using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class ChicagoStore : AStore
    {
        public ChicagoStore()
        {
            Name = "Chicago Pizza Store";
            PresetPizzas = new List<BasicPizza>();
            ToppingsList = new List<Topping>();
            SizeList = new List<Size>();
            CrustList = new List<Crust>();

            // InitToppings();
            // InitSize();
            // InitCrust();
            // InitPresetPizza();
        }

        public void InitTs(APizzaComponent apc)
        {
            //ItemType toppings = new ItemType("topping");
            // AddTopping(0.75m, 100, "beef", apc);
            // AddTopping(1.50m, 100, "chicken", apc);
            // AddTopping(0.57m, 100, "ham", apc);
            // AddTopping(0.45m, 100, "mushroom", apc);
            // AddTopping(0.25m, 100, "olive", apc);
            // AddTopping(0.30m, 100, "peppers", apc);
            // AddTopping(0.50m, 100, "pineapple", apc);
            // AddTopping(0.70m, 100, "salami", apc);
            // AddTopping(0.70m, 100, "sausage", apc);
            // AddTopping(0.50m, 100, "bacon", apc);
            // AddTopping(1.00m, 100, "onion", apc);
            // AddTopping(0.25m, 100, "pepporoni", apc);
            AddTopping(0.75m, 100, apc);
            AddTopping(1.50m, 100, apc);
            AddTopping(0.57m, 100, apc);
            AddTopping(0.45m, 100, apc);
            AddTopping(0.25m, 100, apc);
            AddTopping(0.30m, 100, apc);
            AddTopping(0.50m, 100, apc);
            AddTopping(0.70m, 100, apc);
            AddTopping(0.70m, 100, apc);
            AddTopping(0.50m, 100, apc);
            AddTopping(1.00m, 100, apc);
            AddTopping(0.25m, 100, apc);
        }
        public override void InitSize()
        {
            ItemType size = new ItemType("size");
            AddSize(4.50m, 100, "small", size);
            AddSize(5.50m, 100, "medium", size);
            AddSize(6.50m, 100, "large", size);
        }
        public override void InitCrust()
        {
            ItemType crust = new ItemType("crust");
            AddCrust(0.50m, 100, "regular", crust);
            AddCrust(1.0m, 100, "hand-tossed", crust);
            AddCrust(0.50m, 100, "thin", crust);
        }

        public override void InitPresetPizza()
        {
            /*Meat*/
            BasicPizza tempP = new BasicPizza();
            tempP.Type = "Meat Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[0]);
            tempP.AddTopping(ToppingsList[10]);
            tempP.AddTopping(ToppingsList[2]);
            tempP.AddTopping(ToppingsList[6]);
            tempP.AddTopping(ToppingsList[8]);
            //tempP.CalculatePrice();
            PresetPizzas.Add(tempP);
            /*Deluxe*/
            tempP = new BasicPizza();
            tempP.Type = "Deluxe Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[6]);
            tempP.AddTopping(ToppingsList[9]);
            tempP.AddTopping(ToppingsList[3]);
            tempP.AddTopping(ToppingsList[5]);
            tempP.AddTopping(ToppingsList[11]);
            //tempP.CalculatePrice();
            PresetPizzas.Add(tempP);
        }
    }
}