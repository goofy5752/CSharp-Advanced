using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> reversedNumbers = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                reversedNumbers.Push(numbers[i]);
            }

            while (reversedNumbers.Count > 0)
            {
                Console.Write(reversedNumbers.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}