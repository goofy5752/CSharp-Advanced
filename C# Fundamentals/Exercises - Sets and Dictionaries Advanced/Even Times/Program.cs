using System;
using System.Collections.Generic;

namespace Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            var hash = new HashSet<int>();
            for (int i = 0; i < input; i++)
            {
                int n = int.Parse(Console.ReadLine());
                if (hash.Contains(n))
                {
                    Console.WriteLine(n);
                }
                hash.Add(n);
            }
        }
    }
}