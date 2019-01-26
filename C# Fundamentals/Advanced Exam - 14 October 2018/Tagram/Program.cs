using System;
using System.Collections.Generic;
using System.Linq;

namespace Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dict = new Dictionary<string, Dictionary<string, int>>();
            while (input != "end")
            {
                var splittedInput = input.Split();
                if (splittedInput.Length == 2)
                {
                    if (dict.ContainsKey(splittedInput[1]))
                    {
                        dict.Remove(splittedInput[1]);
                    }
                }
                else
                {
                    var neededInput = input.Split(" -> ");
                    if (!dict.ContainsKey(neededInput[0]))
                    {
                        dict.Add(neededInput[0], new Dictionary<string, int>());
                    }
                    if (!dict[neededInput[0]].ContainsKey(neededInput[1]))
                    {
                        dict[neededInput[0]].Add(neededInput[1], int.Parse(neededInput[2]));
                    }
                    else
                    {
                        dict[neededInput[0]][neededInput[1]] += int.Parse(neededInput[2]);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in dict.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Values.Count))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"- {kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
}