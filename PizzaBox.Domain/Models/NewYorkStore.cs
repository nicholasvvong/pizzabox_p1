using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class NewYorkStore : AStore
    {
        public NewYorkStore()
        {
            Name = "NewYork Pizza Store";
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
        //     AddTopping(1.00m, 100, "beef", toppings);
        //     AddTopping(0.75m, 100, "chicken", toppings);
        //     AddTopping(0.75m, 100, "ham", toppings);
        //     AddTopping(0.40m, 100, "mushroom", toppings);
        //     AddTopping(0.20m, 100, "olive", toppings);
        //     AddTopping(0.35m, 100, "peppers", toppings);
        //     AddTopping(0.65m, 100, "pepporoni", toppings);
        //     AddTopping(0.55m, 100, "pineapple", toppings);
        //     AddTopping(0.80m, 100, "salami", toppings);
        //     AddTopping (0.85m, 100, "sausage", toppings);
        //     AddTopping(1.00m, 100, "meat ball", toppings);
        //     AddTopping (1.20m, 100, "anchovies", toppings);
        // }
        // public override void InitSize()
        // {
        //     ItemType size = new ItemType("size");
        //     AddSize(4.5m, 100, "small", size);
        //     AddSize(5.5m, 100, "large", size);
        //     AddSize(6.5m, 100, "extra large", size);
        // }
        // public override void InitCrust()
        // {
        //     ItemType crust = new ItemType("crust");
        //     AddCrust(1.0m, 100, "regular", crust);
        //     AddCrust(1.0m, 100, "hand-tossed", crust);
        //     AddCrust(1.0m, 100, "thin", crust);
        // }

        // public override void InitPresetPizza()
        // {
        //     /*Meat*/
        //     BasicPizza tempP = new BasicPizza();
        //     tempP.Type = "Meat Pizza";
        //     tempP.AddCrust(CrustList[0]);
        //     tempP.AddTopping(ToppingsList[0]);
        //     tempP.AddTopping(ToppingsList[1]);
        //     tempP.AddTopping(ToppingsList[2]);
        //     tempP.AddTopping(ToppingsList[6]);
        //     tempP.AddTopping(ToppingsList[8]);
        //     tempP.CalculatePrice();
        //     PresetPizzas.Add(tempP);
        //     /*Hawaiian*/
        //     tempP = new BasicPizza();
        //     tempP.Type = "Hawaiian Pizza";
        //     tempP.AddCrust(CrustList[0]);
        //     tempP.AddTopping(ToppingsList[2]);
        //     tempP.AddTopping(ToppingsList[5]);
        //     tempP.AddTopping(ToppingsList[7]);
        //     tempP.CalculatePrice();
        //     PresetPizzas.Add(tempP);
        //     /*Deluxe*/
        //     tempP = new BasicPizza();
        //     tempP.Type = "Deluxe Pizza";
        //     tempP.AddCrust(CrustList[0]);
        //     tempP.AddTopping(ToppingsList[6]);
        //     tempP.AddTopping(ToppingsList[9]);
        //     tempP.AddTopping(ToppingsList[3]);
        //     tempP.AddTopping(ToppingsList[5]);
        //     tempP.AddTopping(ToppingsList[11]);
        //     tempP.CalculatePrice();
        //     PresetPizzas.Add(tempP);
        // }
    }
}