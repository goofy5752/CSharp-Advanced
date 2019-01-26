using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cups = new Queue<int>();
            var bottles = new Stack<int>();
            int[] cupsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < cupsArr.Length; i++)
            {
                cups.Enqueue(cupsArr[i]);
            }
            for (int i = 0; i < bottlesArr.Length; i++)
            {
                bottles.Push(bottlesArr[i]);
            }
            int totalWastedLiters = 0;
            for (int i = 0; i < bottlesArr.Length; i++)
            {
                if (bottles.Peek() >= cups.Peek())
                {
                    totalWastedLiters += bottles.Pop() - cups.Dequeue();
                }
                else
                {
                    int newSum = cups.Dequeue() - bottles.Pop();
                    cups.Enqueue(newSum);
                    for (int k = 0; k < cups.Count - 1; k++)
                    {
                        cups.Enqueue(cups.Dequeue());
                    }
                }
                if (bottles.Count == 0 && cups.Count > 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {totalWastedLiters}");
                    break;
                }
                else if (bottles.Count > 0 && cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                    Console.WriteLine($"Wasted litters of water: {totalWastedLiters}");
                    break;
                }
            }
        }
    }
}