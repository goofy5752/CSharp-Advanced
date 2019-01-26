using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                List<Tire> tires = new List<Tire>();
                for (int j = 0; j < 8; j += 2)
                {
                    double tirePressure = double.Parse(carInfo[5 + j]);
                    int tireAge = int.Parse(carInfo[6 + j]);
                    Tire tire = new Tire(tirePressure, tireAge);
                    tires.Add(tire);
                }
                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            var finalCars = new List<Car>();
            string input = Console.ReadLine();
            if (input == "fragile")
            {
                finalCars = cars.Where(x => x.Cargo.CargoType == "fragile" && x.Tire.Any(v => v.TirePressure < 1)).ToList();
            }
            else
            {
                finalCars = cars.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250).ToList();
            }
            foreach (var item in finalCars)
            {
                Console.WriteLine(item.Model);
            }
        }
    }
}