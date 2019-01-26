using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var hash = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int k = 0; k < input.Length; k++)
                {
                    hash.Add(input[k]);
                }
            }
            Console.WriteLine(string.Join(" ",hash.OrderBy(x => x)));
        }
    }
}