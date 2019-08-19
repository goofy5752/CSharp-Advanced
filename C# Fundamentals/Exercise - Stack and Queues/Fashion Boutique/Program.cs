using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int newRack = 0;
            var stack = new Stack<int>();

            int[] clothesWeight = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            for (int i = 0; i < clothesWeight.Length; i++)
            {
                stack.Push(clothesWeight[i]);
            }

            int totalRacks = 0;

            for (int i = 0; i < clothesWeight.Length; i++)
            {
                newRack += stack.Pop();
                if (newRack >= rackCapacity || (newRack + stack.Peek()) >= rackCapacity)
                {
                    if ((newRack + stack.Peek()) >= rackCapacity)
                    {
                        newRack = 0;
                    }
                    totalRacks++;
                }
            }

            Console.WriteLine(totalRacks);
        }
    }
}