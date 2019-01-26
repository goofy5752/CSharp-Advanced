using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings = new List<Topping>();

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length > 0 && value.Length < 16 && value != string.Empty && !string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
            }
        }

        public Dough Dough
        {
            get => dough;
            set
            {
                this.dough = value;
            }
        }

        public List<Topping> Toppings
        {
            get => toppings;
            set
            {
                toppings = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);
            if (Toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }

        public void AddDough(Dough dough)
        {
            this.Dough = dough;
        }

        private double GetCalories()
        {
            double totalCalories = this.Dough.Calories + this.Toppings.Sum(x => x.Calories);
            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.name} - {GetCalories():F2} Calories.";
        }
    }
}