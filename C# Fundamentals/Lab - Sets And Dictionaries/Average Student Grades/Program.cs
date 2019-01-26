using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], new List<decimal>());
                }
                if (dict.ContainsKey(input[0]))
                {
                    dict[input[0]].Add(decimal.Parse(input[1]));
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value):F2} (avg: {item.Value.Average():F2})");
            }
        }
    }
}