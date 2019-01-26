using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                if (!dict.ContainsKey(input[0]))
                {
                    dict.Add(input[0], int.Parse(input[1]));
                }
            }
            string condition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();
            if (command.Length == 2)
            {
                if (condition == "older")
                {
                    foreach (var item in dict.Where(x => x.Value >= ageCondition))
                    {
                        Console.WriteLine(item.Key + " - " + item.Value);
                    }
                }
                else
                {
                    foreach (var item in dict.Where(x => x.Value <= ageCondition))
                    {
                        Console.WriteLine(item.Key + " - " + item.Value);
                    }
                }
            }
            else if (command[0] == "name")
            {
                if (condition == "older")
                {
                    foreach (var item in dict.Where(x => x.Value >= ageCondition))
                    {
                        Console.WriteLine($"{item.Key}");
                    }
                }
                else
                {
                    foreach (var item in dict.Where(x => x.Value < ageCondition))
                    {
                        Console.WriteLine($"{item.Key}");
                    }
                }
            }
            else
            {
                if (condition == "older")
                {
                    foreach (var item in dict.Where(x => x.Value >= ageCondition))
                    {
                        Console.WriteLine($"{item.Value}");
                    }
                }
                else
                {
                    foreach (var item in dict.Where(x => x.Value < ageCondition))
                    {
                        Console.WriteLine($"{item.Value}");
                    }
                }
            }
        }
    }
}