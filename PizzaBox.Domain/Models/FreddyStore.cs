using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class FreddyStore : AStore
    {
        public FreddyStore()
        {
            Name = "Freddy's Pizza Store";
            PresetPizzas = new List<BasicPizza>();
            ToppingsList = new List<Topping>();
            SizeList = new List<Size>();
            CrustList = new List<Crust>();

            // InitToppings();
            // InitSize();
            // InitCrust();
            // InitPresetPizza();
        }

        // public override void InitToppings()
        // {
        //     ItemType toppings = new ItemType("topping");
        //     AddTopping(1.00m, 100, "mushroom", toppings);
        //     AddTopping(0.40m, 100, "olive", toppings);
        //     AddTopping(0.45m, 100, "peppers", toppings);
        //     AddTopping(0.75m, 100, "pineapple", toppings);
        //     AddTopping(0.33m, 100, "opnions", toppings);
        //     AddTopping(0.50m, 100, "tomatoes", toppings);
        //     AddTopping(0.60m, 100, "spinach", toppings);
        // }
        // public override void InitSize()
        // {
        //     ItemType size = new ItemType("size");
        //     AddSize(5.0m, 100, "medium", size);
        //     AddSize(6.0m, 100, "large", size);
        // }
        // public override void InitCrust()
        // {
        //     ItemType crust = new ItemType("crust");
        //     AddCrust(1.5m, 100, "regular", crust);
        //     AddCrust(2.0m, 100, "hand-tossed", crust);
        //     AddCrust(1.0m, 100, "thin", crust);
        // }

        // public override void InitPresetPizza()
        // {
        //     /*Veggie*/
        //     BasicPizza tempP = new BasicPizza();
        //     tempP.Type = "Basic Veggie Pizza";
        //     tempP.AddCrust(CrustList[0]);
        //     tempP.AddTopping(ToppingsList[0]);
        //     tempP.AddTopping(ToppingsList[1]);
        //     tempP.AddTopping(ToppingsList[4]);
        //     tempP.AddTopping(ToppingsList[6]);
        //     tempP.CalculatePrice();
        //     PresetPizzas.Add(tempP);
        // }
    }
}