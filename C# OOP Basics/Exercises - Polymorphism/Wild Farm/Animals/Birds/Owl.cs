using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            Console.WriteLine(AskForFood());
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Eat(string foodType, int foodQuantity)
        {
            if (foodType.ToLower() == "meat")
            {
                this.Weight += 0.25 * foodQuantity;
                this.FoodEaten += foodQuantity;
            }
            else
            {
                Console.WriteLine($"Owl does not eat {foodType}!");
            }
        }

        public override string ToString()
        {
            return $"Owl [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
