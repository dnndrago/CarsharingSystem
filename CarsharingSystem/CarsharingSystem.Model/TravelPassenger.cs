
namespace CarsharingSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TravelPassenger
    {
        [Key, Column(Order = 0)]
        public Guid TravelId { get; set; }

        public Travel Travel { get; set; }

        [Key, Column(Order = 1)]
        public string PassengerId { get; set; }

        public Passenger Passenger { get; set; }

        public bool IsVoted { get; set; }
    }
}
