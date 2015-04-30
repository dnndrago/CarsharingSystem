
namespace CarsharingSystem.WebServices.Models
{
    using System;
    using System.Collections.Generic;

    public class TravelOutputModel
    {
        public string DriverId { get; set; }

        public List<string> PassengerIds { get; set; }

        public string VehicleId { get; set; }

        public string Status { get; set; }

        public DateTime TravelDate { get; set; }

        public string DestinationFrom { get; set; }

        public string DestinationTo { get; set; }
    }
}