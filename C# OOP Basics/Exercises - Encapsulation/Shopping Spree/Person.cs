using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
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

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    Exception exception = new ArgumentException("Money cannot be negative");
                    Console.WriteLine(exception.Message);
                    Environment.Exit(0);
                }
                money = value;
            }
        }

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public void Add(Product product)
        {
            decimal cost = product.Cost;
            string productName = product.Name;
            if (cost > this.money)
            {
                Console.WriteLine($"{this.Name} can't afford {productName}");
            }
            else
            {
                this.Products.Add(product);
                this.Money -= cost;
                Console.WriteLine($"{this.Name} bought {productName}");
            }
        }

        public override string ToString()
        {
            if (Products.Count > 0)
            {
                return $"{this.name} - {string.Join(", ", this.Products.Select(x => x.ToString()))}";
            }
            else
            {
                return $"{this.name} - Nothing bought";
            }
        }
    }
}