
namespace CarsharingSystem.Model
{
    using System;
    using System.Collections.Generic;

    public class Travel
    {
        public Travel()
        {
            this.Id = Guid.NewGuid();
            this.Passengers = new HashSet<TravelPassenger>();
        }

        public Guid Id { get; set; }

        public string DriverId { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual ICollection<TravelPassenger> Passengers { get; set; }

        public Guid VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public TravelStatus Status { get; set; }

        public DateTime TravelDate { get; set; }

        public string FromDestination { get; set; }

        public string ToDestionation { get; set; }
    }
}
