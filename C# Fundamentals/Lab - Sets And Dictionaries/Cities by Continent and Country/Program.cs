using System;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], new Dictionary<string, List<string>>());
                }
                if (!dict[input[0]].ContainsKey(input[1]))
                {
                    dict[input[0]].Add(input[1], new List<string>());
                }
                dict[input[0]][input[1]].Add(input[2]);
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var kvp in item.Value)
                {
                    Console.WriteLine($"{kvp.Key} -> {String.Join(", ", kvp.Value)}");
                }
            }
        }
    }
}