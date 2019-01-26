using System;
using System.Collections.Generic;
using System.Linq;

namespace Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int infoNeededToPass = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            var dict = new Dictionary<string, Dictionary<string, string>>();
            while (input != "end transmissions")
            {
                var splittedInput = input.Split('=');
                var name = splittedInput[0];
                if (splittedInput[1].Contains(';'))
                {
                    var elements = splittedInput[1].Split(';');
                    for (int i = 0; i < elements.Length; i++)
                    {
                        var splittedElements = elements[i].Split(':');
                        if (!dict.ContainsKey(name))
                        {
                            dict.Add(name, new Dictionary<string, string>());
                        }
                        if (!dict[name].ContainsKey(splittedElements[0]))
                        {
                            dict[name].Add(splittedElements[0], splittedElements[1]);
                        }
                        else
                        {
                            dict[name][splittedElements[0]] = splittedElements[1];
                        }
                    }
                }
                else
                {
                    var splittedElements = splittedInput[1].Split(':');
                    if (!dict.ContainsKey(name))
                    {
                        dict.Add(name, new Dictionary<string, string>());
                    }
                    if (!dict[name].ContainsKey(splittedElements[0]))
                    {
                        dict[name].Add(splittedElements[0], splittedElements[1]);
                    }
                    else
                    {
                        dict[name][splittedElements[0]] = splittedElements[1];
                    }
                }
                input = Console.ReadLine();
            }
            string[] kill = Console.ReadLine().Split();
            Console.WriteLine($"Info on {kill[1]}:");
            foreach (var item in dict[kill[1]].OrderBy(x => x.Key))
            {
                Console.WriteLine($"---{item.Key}: {item.Value}");
            }
            int counter = 0;
            foreach (var item in dict[kill[1]])
            {
                counter += item.Key.ToCharArray().Count();
                counter += item.Value.ToCharArray().Count();
            }
            Console.WriteLine($"Info index: {counter}");
            if (counter >= infoNeededToPass)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {infoNeededToPass - counter} more info.");
            }
        }
    }
}