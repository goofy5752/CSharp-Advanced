using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var dict = new Dictionary<string, Dictionary<string, List<string>>>();
            var list = new SortedSet<string>();
            while (input != "Output")
            {
                string[] splittedInput = input.Split();
                if (splittedInput.Length == 4)
                {
                    string department = splittedInput[0];
                    string doctorName = splittedInput[1] + " " + splittedInput[2];
                    string patientName = splittedInput[3];
                    if (!dict.ContainsKey(department))
                    {
                        dict.Add(department, new Dictionary<string, List<string>>());
                    }
                    else
                    {
                        dict[department].Add(doctorName, new List<string>());
                    }
                    if (!dict[department].ContainsKey(doctorName))
                    {
                        dict[department].Add(doctorName, new List<string>());
                    }
                    dict[department][doctorName].Add(patientName);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                string[] splittedInput = input.Split();
                if (splittedInput.Length == 1)
                {
                    foreach (var item in dict[splittedInput[0]])
                    {
                        Console.WriteLine(string.Join("", item.Value));
                    }
                }
                else if (splittedInput[1].Length == 1)
                {
                    foreach (var item in dict[splittedInput[0]].Values.OrderBy(x => x))
                    {
                        Console.WriteLine(string.Join("", item));
                    }
                }
                else
                {
                    var printDict = new Dictionary<string, SortedSet<string>>();
                    foreach (var item in dict)
                    {
                        foreach (var kvp in item.Value)
                        {
                            if (kvp.Key == input)
                            {
                                if (!printDict.ContainsKey(kvp.Key))
                                {
                                    printDict.Add(kvp.Key, new SortedSet<string>());
                                }
                                printDict[kvp.Key].Add(string.Join("", kvp.Value.ToString()));
                            }
                        }
                    }
                    foreach (var item in printDict.Values)
                    {
                        Console.WriteLine(string.Join("",item.ToString()));
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}