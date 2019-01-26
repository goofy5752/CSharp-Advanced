using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            Console.WriteLine(AskForFood());
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override void Eat(string foodType, int foodQuantity)
        {
            if (foodType.ToLower() == "meat")
            {
                this.Weight += 1.00 * foodQuantity;
                this.FoodEaten += foodQuantity;
            }
            else
            {
                Console.WriteLine($"Tiger does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Tiger [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}