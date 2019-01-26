using System;
using System.Linq;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(n.Count());
            Console.WriteLine(n.Sum());
        }
    }
}