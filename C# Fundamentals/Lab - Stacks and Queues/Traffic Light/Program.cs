using System;
using System.Collections.Generic;

namespace Traffic_Light
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPerGreenLightPass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string input = Console.ReadLine();
            int counter = 0;
            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < carsPerGreenLightPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                        if (cars.Count == 0)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}