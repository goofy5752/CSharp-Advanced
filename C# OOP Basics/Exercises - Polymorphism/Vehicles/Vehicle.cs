using System;

namespace Vehicles
{
    public abstract class Vehicle : IRideable
    {
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKM, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKM = fuelConsumptionPerKM;
            this.TankCapacity = tankCapacity;
            if (tankCapacity < fuelQuantity)
            {
                this.FuelQuantity = 0;
            }
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumptionPerKM { get; set; }

        public double TankCapacity
        {
            get => tankCapacity;
            protected set
            {
                tankCapacity = value;
            }
        }

        public virtual void Drive(double kilometresToDrive)
        {
            double totalFuelToConsume = kilometresToDrive * this.FuelConsumptionPerKM;
            if (totalFuelToConsume < FuelQuantity)
            {
                FuelQuantity -= totalFuelToConsume;
                Console.WriteLine($" travelled {kilometresToDrive} km");

            }
            else
            {
                Console.WriteLine(" needs refueling");
            }
        }

        public virtual void Refuel(string vehicle, double refuelAmount)
        {
            if (refuelAmount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (refuelAmount > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {refuelAmount} fuel in the tank");
                return;
            }
            if (vehicle == "Truck")
            {
                this.FuelQuantity += refuelAmount * 0.95;
            }
            else
            {
                this.FuelQuantity += refuelAmount;
            }
        }
    }
}