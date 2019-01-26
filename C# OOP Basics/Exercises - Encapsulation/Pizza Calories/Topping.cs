using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string name;
        private double weight;

        public Topping(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.ToLower() == "meat" 
                    || value.ToLower() == "veggies" 
                    || value.ToLower() == "cheese" 
                    || value.ToLower() == "sauce")
                {
                     name = value;
                }
                else
                {
                    string nameToUpper = char.ToUpper(value[0]) + value.Substring(1);
                    throw new ArgumentException($"Cannot place {nameToUpper} on top of your pizza.");
                }
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value > 0 && value < 51)
                {
                    weight = value;
                }
                else
                {
                    string nameToUpper = char.ToUpper(this.Name[0]) + this.Name.Substring(1);
                    throw new ArgumentException($"{nameToUpper} weight should be in the range [1..50].");
                }
            }
        }

        public double Calories { get => CalculateToppingCalories(); }

        private double CalculateToppingCalories()
        {
            double toppingCalories = 2 * this.Weight;
            if (this.Name.ToLower() == "meat")
            {
                toppingCalories *= 1.2;
            }
            else if (this.Name.ToLower() == "veggies")
            {
                toppingCalories *= 0.8;
            }
            else if (this.Name.ToLower() == "cheese")
            {
                toppingCalories *= 1.1;
            }
            else
            {
                toppingCalories *= 0.9;
            }
            return toppingCalories;
        }
    }
}