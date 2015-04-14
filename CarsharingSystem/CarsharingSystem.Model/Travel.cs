
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

        public Driver Driver { get; set; }

        public ICollection<Passenger> Passengers { get; set; }
    }
}
