
namespace CarsharingSystem.WebServices.Models
{
    using System;

    using CarsharingSystem.Model;

    public class TravelInputModel
    {
        public string VehicleId { get; set; }

        public DateTime? TravelDate { get; set; }

        public string DestinationFrom { get; set; }

        public string DestinationTo { get; set; }

        public TravelStatus? TravelStatus { get; set; }
    }
}