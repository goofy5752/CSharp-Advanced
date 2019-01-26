using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            Console.WriteLine(AskForFood());
        }

        public override string AskForFood()
        {
            return "Woof!";
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
                Console.WriteLine($"Dog does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Dog [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}