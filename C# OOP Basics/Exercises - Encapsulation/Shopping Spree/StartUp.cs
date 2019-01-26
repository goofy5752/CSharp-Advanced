using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleAndTheirMoney = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsAndTheirPrices = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleAndTheirMoney.Length; i++)
            {
                var splittedPeople = peopleAndTheirMoney[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string personName = splittedPeople[0];
                decimal personMoney = decimal.Parse(splittedPeople[1]);
                Person person = new Person(personName, personMoney);
                people.Add(person);
            }

            for (int i = 0; i < productsAndTheirPrices.Length; i++)
            {
                var splittedProducts = productsAndTheirPrices[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                string productName = splittedProducts[0];
                decimal productPrice = decimal.Parse(splittedProducts[1]);
                Product product = new Product(productName, productPrice);
                products.Add(product);
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END")
                {
                    break;
                }
                string personName = input[0];
                string productName = input[1];
                people.First(x => x.Name == personName)
                    .Add(products.First(x => x.Name == productName));
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}