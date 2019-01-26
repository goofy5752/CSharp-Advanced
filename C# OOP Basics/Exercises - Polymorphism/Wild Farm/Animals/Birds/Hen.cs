using System;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            Console.WriteLine(AskForFood());
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Eat(string foodType, int foodQuantity)
        {
            this.Weight += 0.35 * foodQuantity;
            this.FoodEaten += foodQuantity;
        }

        public override string ToString()
        {
            return $"Hen [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
