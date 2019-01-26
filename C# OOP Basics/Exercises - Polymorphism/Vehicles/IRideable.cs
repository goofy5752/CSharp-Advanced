using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IRideable
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKM { get; }
        double TankCapacity { get; }
    }
}