
namespace CarsharingSystem.WebServices.Models
{
    using System;

    public class DrivingLicenseInputModel
    {
        public string LicenseNumber { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string Categories { get; set; }
    }
}