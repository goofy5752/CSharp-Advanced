using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKM, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKM + 1.6, tankCapacity)
        {
        }

        public override void Drive(double kilometresToDrive)
        {
            Console.Write("Truck");
            base.Drive(kilometresToDrive);
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:F2}";
        }
    }
}
