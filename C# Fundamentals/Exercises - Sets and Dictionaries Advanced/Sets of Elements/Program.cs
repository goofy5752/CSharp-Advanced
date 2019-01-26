using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var hash1 = new HashSet<int>();
            var hash2 = new HashSet<int>();
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 1; i <= n.Sum(); i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (i <= n[0])
                {
                    hash1.Add(input);
                }
                else
                {
                    hash2.Add(input);
                }
            }
            int getMax = Math.Max(hash1.Count, hash2.Count);
            foreach (var item in hash1)
            {
                if (hash2.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}