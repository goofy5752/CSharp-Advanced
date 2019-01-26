using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string outterKey = input.Split().First().ToString();
               
                string[] elements = input.Split(" -> ");
                var innerKey = new List<string>();
                if (elements.Count() > 1)
                {
                    innerKey.AddRange(elements[1].Split(','));
                }
                else
                {
                    innerKey.Add(elements[1]);
                }
                if (!dict.ContainsKey(outterKey))
                {
                    dict.Add(outterKey, new Dictionary<string, int>());
                }
                for (int k = 0; k < innerKey.Count; k++)
                {
               
                    if (!dict[outterKey].ContainsKey(innerKey[k]))
                    {
                        dict[outterKey].Add(innerKey[k], 0);
                    }
                    dict[outterKey][innerKey[k]]++;
                }
            }
            string searchedCloth = Console.ReadLine();
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key.ToString()} clothes:");
                foreach (var kvp in item.Value)
                {
                    if (searchedCloth == item.Key + " " + kvp.Key)
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}