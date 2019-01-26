using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKM, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKM + 1.6, tankCapacity)
        {
        }

        public override void Drive(double kilometresToDrive)
        {
            Console.Write("Car");
            base.Drive(kilometresToDrive);
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:F2}";
        }
    }
}