namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport : IAirport
	{
		private List<IBag> confiscatedBags;
		private List<IBag> checkedInBags;
		private List<ITrip> trips;
		private List<IPassenger> passengers;

        public Airport()
        {
            this.confiscatedBags = new List<IBag>();
            this.checkedInBags = new List<IBag>();
            this.trips = new List<ITrip>();
            this.passengers = new List<IPassenger>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => checkedInBags.AsReadOnly();

        public IReadOnlyCollection<IBag> ConfiscatedBags => confiscatedBags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => passengers.AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => trips.AsReadOnly();

        public IPassenger GetPassenger(string username)
        {
            return passengers.Where(x => x.Username == username).First();
        }

		public ITrip GetTrip(string id)
        {
            return trips.Where(x => x.Id == id).First();
        }

		public void AddPassenger(IPassenger passenger)
        {
            passengers.Add(passenger);
        }

		public void AddTrip(ITrip trip)
        {
            trips.Add(trip);
        }

		public void AddCheckedBag(IBag bag)
        {
            checkedInBags.Add(bag);
        }

		public void AddConfiscatedBag(IBag bag)
        {
            confiscatedBags.Add(bag);
        }
	}
}