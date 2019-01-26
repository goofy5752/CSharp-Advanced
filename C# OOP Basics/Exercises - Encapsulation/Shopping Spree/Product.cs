using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Exception exception = new ArgumentException("Name cannot be empty");
                    Console.WriteLine(exception.Message);
                    Environment.Exit(0);
                }
                name = value;
            }
        }
        
        public decimal Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    Exception exception = new ArgumentException("Money cannot be negative");
                    Console.WriteLine(exception.Message);
                    Environment.Exit(0);
                }
                cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}