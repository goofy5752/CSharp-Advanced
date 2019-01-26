using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => flourType;
            set
            {
                if (value.ToLower() == "wholegrain" || value.ToLower() == "white")
                {
                    flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                if (value.ToLower() == "crispy" 
                    || value.ToLower() == "chewy" 
                    || value.ToLower() == "homemade")
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value >= 1 && value <= 200)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }

        public double Calories { get => CalculateDoughtCalories(); }

        private double CalculateDoughtCalories()
        {
            double totalCalories = 2 * this.Weight;
            if (this.FlourType.ToLower() == "white")
            {
                totalCalories *= 1.5;
            }
            else
            {
                totalCalories *= 1.0;
            }
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                totalCalories *= 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                totalCalories *= 1.1;
            }
            else
            {
                totalCalories *= 1.0;
            }
            return totalCalories;
        }
    }
}