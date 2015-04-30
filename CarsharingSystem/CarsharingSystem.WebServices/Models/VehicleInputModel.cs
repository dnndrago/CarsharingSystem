
namespace CarsharingSystem.WebServices.Models
{
    using System;

    using CarsharingSystem.Model;

    public class VehicleInputModel
    {
        public DateTime? ManufactureDate { get; set; }

        public VehicleType? VehicleType { get; set; }

        public int? Seats { get; set; }

        public int? Run { get; set; }
    }
}