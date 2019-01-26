using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Airplanes
{
    public class MediumAirplane : Airplane
    {
        private const int MediumAirplaneSeat = 10;
        private const int MediumAirplaneBaggageCompartment = 14;

        public MediumAirplane() : 
            base(MediumAirplaneSeat, MediumAirplaneBaggageCompartment)
        {
        }
    }
}