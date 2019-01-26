using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes
{
    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;
        private List<IBag> ejectedBaggage;

        public Airplane(int seat, int baggageCompartment)
        {
            this.Seats = seat;
            this.BaggageCompartments = baggageCompartment;

            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
            this.ejectedBaggage = new List<IBag>();
        }

        public int BaggageCompartments { get; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

        public bool IsOverbooked => passengers.Count > Seats;

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public int Seats { get; }

        public void AddPassenger(IPassenger passenger)
        {
            passengers.Add(passenger);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var removedBaggage = baggageCompartment.Where(x => x.Owner.Username == passenger.Username).First();
            ejectedBaggage.Add(removedBaggage);
            baggageCompartment.RemoveAll(x => x.Owner.Username == passenger.Username);
            return ejectedBaggage;
        }

        public void LoadBag(IBag bag)
        {
            if (BaggageCompartment.Count > BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}");
            }

            this.baggageCompartment.Add(bag);
        }

        public IPassenger RemovePassenger(int seat)
        {
            var removedPassenger = passengers[seat];
            passengers.RemoveAt(seat);
            return removedPassenger;
        }
    }
}
