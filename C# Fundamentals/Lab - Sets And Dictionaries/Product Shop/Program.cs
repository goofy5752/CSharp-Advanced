using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var dict = new Dictionary<string, Dictionary<string, double>>();
            while (input[0] != "Revision")
            {
                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], new Dictionary<string, double>());
                }
                if (dict.ContainsKey(input[0]))
                {
                    dict[input[0]].Add(input[1], double.Parse(input[2]));
                }
                input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            foreach (var item in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}->");
                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"Product: {string.Join("",kvp.Key)}, Price: {string.Join("",kvp.Value)}");
                }
            }
        }
    }
}