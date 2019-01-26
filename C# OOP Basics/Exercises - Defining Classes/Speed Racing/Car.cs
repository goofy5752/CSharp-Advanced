using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public string CarModel { get; set; }
        public double FuelAmount { get; set; }
        public double LiterPerKM { get; set; }
        public double DistanceTraveled { get; set; }

        public Car(string carModel, double fuelAmount, double literPerKM)
        {
            this.CarModel = carModel;
            this.FuelAmount = fuelAmount;
            this.LiterPerKM = literPerKM;
            this.DistanceTraveled = 0;
        }

        public bool CanMove(double wantedDistanceToCover)
        {
            double fuelToConsume = wantedDistanceToCover * this.LiterPerKM;

            if (this.FuelAmount < fuelToConsume) return false;
           

            Reduce(fuelToConsume);
            return true;
        }

        private void Reduce(double fuelToConsume)
        {
            this.DistanceTraveled += fuelToConsume / LiterPerKM;

            this.FuelAmount -= fuelToConsume;
        }

        public override string ToString()
        {
            return $"{this.CarModel} {this.FuelAmount:F2} {this.DistanceTraveled}";
        }
    }
}