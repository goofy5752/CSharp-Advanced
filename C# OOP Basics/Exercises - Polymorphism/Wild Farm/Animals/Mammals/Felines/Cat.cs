using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            Console.WriteLine(AskForFood());
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Eat(string foodType, int foodQuantity)
        {
            if (foodType.ToLower() == "vegetable" || foodType.ToLower() == "meat")
            {
                this.Weight += 0.30 * foodQuantity;
                this.FoodEaten += foodQuantity;
            }
            else
            {
                Console.WriteLine($"Cat does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Cat [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}