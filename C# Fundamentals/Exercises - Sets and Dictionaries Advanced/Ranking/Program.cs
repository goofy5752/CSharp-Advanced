using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var contestAndPasswords = new Dictionary<string, string>();
            var finalResults = new Dictionary<string, Dictionary<string, int>>();
            while (input != "end of submissions")
            {
                if (input.Contains(':'))
                {
                    string contest = input.Split(':').First();
                    string password = input.Split(':').Last();
                    if (!contestAndPasswords.ContainsKey(contest))
                    {
                        contestAndPasswords.Add(contest, password);
                    }
                }
                if (input == "end of contests")
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (input.Contains("=>"))
                {
                    string contestName = input.Split("=>").First();
                    int points = int.Parse(input.Split("=>").Last());
                    var splittedInput = input.Split("=>");
                    string password = splittedInput[1];
                    string studentsName = splittedInput[2];
                    if (contestAndPasswords.ContainsKey(contestName) && contestAndPasswords.ContainsValue(password))
                    {
                        if (!finalResults.ContainsKey(studentsName))
                        {
                            finalResults.Add(studentsName, new Dictionary<string, int>());
                        }
                        if (!finalResults[studentsName].ContainsKey(contestName))
                        {
                            finalResults[studentsName].Add(contestName, points);
                        }
                        else
                        {
                            if (finalResults[studentsName][contestName] < points)
                            {
                                finalResults[studentsName][contestName] = points;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in finalResults.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value.Values.Sum()} points.");
                break;
            }
            Console.WriteLine("Ranking:");
            foreach (var item in finalResults.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (var kvp in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}