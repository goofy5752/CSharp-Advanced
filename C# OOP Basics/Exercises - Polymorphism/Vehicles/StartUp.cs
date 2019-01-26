using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            string[] car = Console.ReadLine().Split();
            string[] truck = Console.ReadLine().Split();
            string[] bus = Console.ReadLine().Split();

            Vehicle car1 = new Car(double.Parse(car[1]),
                double.Parse(car[2]), double.Parse(car[3]));
            Vehicle truck1 = new Truck(double.Parse(truck[1]),
                double.Parse(truck[2]), double.Parse(truck[3]));
            Vehicle bus1 = new Bus(double.Parse(bus[1]), double.Parse(bus[2]), double.Parse(bus[3]));
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Drive" || input[0] == "DriveEmpty")
                {
                    if (input[1] == "Car")
                    {
                        car1.Drive(double.Parse(input[2]));
                    }
                    else if (input[1] == "Truck")
                    {
                        truck1.Drive(double.Parse(input[2]));
                    }
                    else
                    {
                        if (input[0] == "DriveEmpty")
                        {
                            bus1.Drive(double.Parse(input[2]));
                        }
                        else
                        {
                            bus1.FuelConsumptionPerKM += 1.4;
                            bus1.Drive(double.Parse(input[2]));
                            bus1.FuelConsumptionPerKM -= 1.4;
                        }
                    }
                }
                else
                {
                    if (input[1] == "Car")
                    {
                        car1.Refuel(input[1], double.Parse(input[2]));
                    }
                    else if (input[1] == "Truck")
                    {
                        truck1.Refuel(input[1], double.Parse(input[2]));
                    }
                    else
                    {
                        bus1.Refuel(input[1], double.Parse(input[2]));
                    }
                }
            }

            Console.WriteLine(car1.ToString());
            Console.WriteLine(truck1.ToString());
            Console.WriteLine(bus1.ToString());
        }
    }
}