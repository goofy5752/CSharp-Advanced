using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                if (input.Length == 1)
                {
                    if (input.Contains(2))
                    {
                        numbers.Pop();
                    }
                    else
                    {
                        Console.WriteLine(numbers.Max());
                    }
                }
                else
                {
                    numbers.Push(input[1]);
                }
            }
        }
    }
}