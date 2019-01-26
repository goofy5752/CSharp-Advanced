using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            Queue<int[]> petrolPumps = new Queue<int[]>();
            int counter = 0;
            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] petrolInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                petrolPumps.Enqueue(petrolInfo);
            }
            while (true)
            {
                int totalSum = 0;
                foreach (var item in petrolPumps)
                {
                    int pumpPetrol = item[0];
                    int distanceToNextPump = item[1];
                    totalSum += pumpPetrol - distanceToNextPump;

                    if (totalSum < 0)
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        counter++;
                        break;
                    }
                }
                if (totalSum > 0)
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}