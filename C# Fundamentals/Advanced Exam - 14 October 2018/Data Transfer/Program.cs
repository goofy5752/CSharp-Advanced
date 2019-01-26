using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Data_Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "s:([^;]+);r:([^;]+);m--(\"[A-Za-z\\s]+\")";
            int n = int.Parse(Console.ReadLine());
            var senderList = new List<string>();
            var receiverList = new List<string>();
            var message = new List<string>();
            int totalLeters = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var isMatch = Regex.Match(input, pattern);
                if (isMatch.Success)
                {
                    foreach (var item in isMatch.Groups[1].Value)
                    {
                        if (char.IsLetter(item) || char.IsWhiteSpace(item))
                        {
                            senderList.Add(item.ToString());
                        }
                        if (char.IsDigit(item))
                        {
                            totalLeters += int.Parse(item.ToString());
                        }
                    }
                    foreach (var item in isMatch.Groups[2].Value)
                    {
                        if (char.IsLetter(item) || char.IsWhiteSpace(item))
                        {
                            receiverList.Add(item.ToString());
                        }
                        if (char.IsDigit(item))
                        {
                            totalLeters += int.Parse(item.ToString());
                        }
                    }
                    message.Add(isMatch.Groups[3].Value);
                    Console.WriteLine($"{string.Join("", senderList)} says {string.Join("", message)} to {string.Join("", receiverList)}");
                    senderList.Clear();
                    receiverList.Clear();
                    message.Clear();
                }
            }
            Console.WriteLine($"Total data transferred: {totalLeters}MB");
        }
    }
}