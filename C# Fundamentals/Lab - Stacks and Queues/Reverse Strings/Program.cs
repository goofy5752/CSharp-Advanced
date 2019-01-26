using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> reversed = new Stack<string>();
            string input = Console.ReadLine();

            foreach (var item in input)
            {
                reversed.Push(item.ToString());
            }

            while (reversed.Count > 0)
            {
                Console.Write(reversed.Pop());
            }
            Console.WriteLine();
        }
    }
}