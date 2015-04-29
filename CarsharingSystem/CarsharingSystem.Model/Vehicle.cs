
namespace CarsharingSystem.Model
{
    using System;

    public class Vehicle
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Guid DriverId { get; set; }

        public virtual Driver Driver { get; set; }

        public DateTime ManufactureDate { get; set; }

        public VehicleType VehicleType { get; set; }

        public int Seats { get; set; }

        public int Run { get; set; }
    }
}
