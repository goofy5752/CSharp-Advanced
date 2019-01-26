using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int secondsPerGreenLight = int.Parse(Console.ReadLine());
            int secondsAfterGreenlight = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int counter = 0;
            string queue = "";
            string crashedCar = "";
            int totalSeconds = secondsPerGreenLight + secondsAfterGreenlight;
            while (input != "END")
            {
                if (input != "green")
                {
                    queue += input + " ";
                }
                else
                {
                    string[] allCars = queue.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in allCars)
                    {
                        if (item.ToCharArray().Length > secondsAfterGreenlight + secondsPerGreenLight)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{item} was hit at {item[item.Length - (secondsPerGreenLight + secondsAfterGreenlight)]}.");
                            break;
                        }
                        if (item.ToCharArray().Length < secondsAfterGreenlight + secondsPerGreenLight)
                        {
                            
                            totalSeconds -= item.ToCharArray().Length;
                            if (totalSeconds < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{item} was hit at {item[item.Length - (secondsPerGreenLight + secondsAfterGreenlight)]}");
                            }
                            counter++;
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}