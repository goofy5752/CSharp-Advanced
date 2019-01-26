using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var Cars = new HashSet<Car>();
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split().ToArray();
                var name = tokens[0];
                var fuel = double.Parse(tokens[1]);
                var consumption = double.Parse(tokens[2]);
                var car = new Car(name, fuel, consumption);
                Cars.Add(car);
            }

            while (true)
            {
                var tokens = Console.ReadLine().Split();

                if (tokens[0] == "End") break;


                var carModel = tokens[1];
                var distance = double.Parse(tokens[2]);

                if (Cars.First(x => x.CarModel == carModel).CanMove(distance)) continue;
                else Console.WriteLine("Insufficient fuel for the drive");

            }
            Console.WriteLine(string.Join(Environment.NewLine, Cars));
        }
    }
}