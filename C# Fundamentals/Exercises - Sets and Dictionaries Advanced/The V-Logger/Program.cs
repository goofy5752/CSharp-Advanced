using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var dict = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string vlogger;
            string action;
            string third;
            while (input[0] != "Statistics")
            {
                vlogger = input[0];
                action = input[1];
                third = input[2];
                if (action == "joined")
                {
                    if (!dict.ContainsKey(vlogger))
                    {
                        dict.Add(vlogger, new Dictionary<string, SortedSet<string>>());
                        dict[vlogger].Add("followers", new SortedSet<string>());
                        dict[vlogger].Add("following", new SortedSet<string>());
                    }
                }
                else
                {
                    if (vlogger == third)
                    {
                        input = Console.ReadLine().Split();
                        continue;
                    }
                    if (dict.ContainsKey(vlogger) && dict.ContainsKey(third))
                    {
                        dict[vlogger]["following"].Add(third);
                        dict[third]["followers"].Add(vlogger);
                    }
                }
                input = Console.ReadLine().Split();
            }
            int counter = 1;
            Console.WriteLine($"The V-Logger has a total of {dict.Count} vloggers in its logs.");

            foreach (var item in dict.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");
                if (counter == 1)
                {
                    foreach (var kvp in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {kvp}");
                    }
                }
                counter++;
            }
        }
    }
}