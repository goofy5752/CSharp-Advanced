using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine()
                    .Split()
                    .Last();
                string[] pizzaDoughtAndTechnique = Console.ReadLine().Split();
                string pizzaDough = pizzaDoughtAndTechnique[1];
                string pizzaTechnique = pizzaDoughtAndTechnique[2];
                double pizzaWeight = double.Parse(pizzaDoughtAndTechnique[3]);

                Pizza pizza = new Pizza(pizzaName);
                Dough dough = new Dough(pizzaDough, pizzaTechnique, pizzaWeight);
                pizza.AddDough(dough);
                while (true)
                {
                    string[] toppings = Console.ReadLine()
                        .Split();
                    if (toppings[0] == "END")
                    {
                        break;
                    }
                    string pizzaTopping = toppings[1];
                    double toppingWeight = double.Parse(toppings[2]);
                    Topping topping = new Topping(pizzaTopping, toppingWeight);
                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}