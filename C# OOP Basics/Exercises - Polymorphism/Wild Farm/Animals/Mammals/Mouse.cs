using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            Console.WriteLine(AskForFood());
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override void Eat(string foodType, int foodQuantity)
        {
            if (foodType.ToLower() == "vegetable" || foodType.ToLower() == "fruit")
            {
                this.Weight += 0.10 * foodQuantity;
                this.FoodEaten += foodQuantity;
            }
            else
            {
                Console.WriteLine($"Mouse does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Mouse [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}