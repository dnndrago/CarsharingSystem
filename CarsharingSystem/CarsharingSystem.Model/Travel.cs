
namespace CarsharingSystem.Model
{
    using System;
    using System.Collections.Generic;

    public class Travel
    {
        public Travel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Guid DriverId { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }

        public Guid VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }    
    }
}
