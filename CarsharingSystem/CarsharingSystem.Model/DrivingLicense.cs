
namespace CarsharingSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DrivingLicense
    {
        private ICollection<DrivingLicenseCategories> categories; 

        public DrivingLicense()
        {
            this.Id = Guid.NewGuid();
            this.categories = new HashSet<DrivingLicenseCategories>();
        }

        public Guid Id { get; set; }

        public Guid DriverId { get; set; }

        public virtual Driver Driver { get; set; }

        public string LicenseNumber { get; set; }

        public virtual ICollection<DrivingLicenseCategories> Categories
        {
            get
            {
                return this.categories;
            }

            set
            {
                this.categories = value;
            }
        }

        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
