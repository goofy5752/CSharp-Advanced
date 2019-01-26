using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> numbers = new Queue<int>();
            int totalNumbers = input[0];
            int numbersToPop = input[1];
            int numberToFind = input[2];
            int[] numberss = new int[totalNumbers];
            numberss = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < numberss.Length; i++)
            {
                numbers.Enqueue(numberss[i]);
            }

            for (int i = 0; i < numbersToPop; i++)
            {
                numbers.Dequeue();
            }
            if (numbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (numbers.Contains(numberToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
        }
    }
}