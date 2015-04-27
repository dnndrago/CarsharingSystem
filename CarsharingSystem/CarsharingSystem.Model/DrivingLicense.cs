
namespace CarsharingSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class DrivingLicense
    {
        public DrivingLicense()
        {
        }

        public int Id { get; set; }

        public Guid DriverId { get; set; }

        public virtual Driver Driver { get; set; }

        public string LicenseNumber { get; set; }

        [NotMapped]
        public virtual ICollection<Category> Categories
        {
            get
            {
                var categories = this.DrivingLicenseCategories.Split(',');

                return categories.Select(category => (Category)Enum.Parse(typeof(Category), category)).ToList();
            }
        }

        public string DrivingLicenseCategories { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
