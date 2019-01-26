using System;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKM, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKM, tankCapacity)
        {
        }

        public override void Drive(double kilometresToDrive)
        {
            Console.Write("Bus");
            base.Drive(kilometresToDrive);
        }

        public override string ToString()
        {
            return $"Bus: {this.FuelQuantity:F2}";
        }
    }
}
