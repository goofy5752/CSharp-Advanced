using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();

            int foodCount = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            int[] foodInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            foreach (var t in foodInfo)
            {
                queue.Enqueue(t);
            }

            int queueCount = queue.Count;
            int queueLargestNumber = queue.Max();

            for (int i = 0; i < queueCount; i++)
            {
                if (foodCount < queue.Peek())
                {
                    Console.WriteLine(queueLargestNumber);
                    Console.WriteLine($"Orders left: {string.Join(',', queue)}");
                    break;
                }

                foodCount -= queue.Dequeue();

                if (queue.Count == 0)
                {
                    Console.WriteLine(queueLargestNumber);
                    Console.WriteLine("Orders complete");
                }
            }
        }
    }
}