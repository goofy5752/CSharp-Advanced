using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Airplanes
{
    public class LightAirplane : Airplane
    {
        private const int LightAirplaneSeat = 5;
        private const int LightAirplaneBaggageCompartment = 8;

        public LightAirplane() 
            : base(LightAirplaneSeat, LightAirplaneBaggageCompartment)
        {
        }
    }
}