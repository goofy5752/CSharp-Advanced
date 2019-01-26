using System;
using System.Linq;

namespace Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(", ", input.Where(x => x % 2 == 0).OrderBy(x => x)));
        }
    }
}