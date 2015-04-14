
namespace CarsharingSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Drivers")]
    public class Driver : ApplicationUser
    {
        private ICollection<Vehicle> vehicles;

        private ICollection<Travel> travels;

        public Driver()
        {
            this.vehicles = new HashSet<Vehicle>();
            this.travels = new HashSet<Travel>();
        }

        public virtual ICollection<Vehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }

            set
            {
                this.vehicles = value;
            }
        }


        public virtual ICollection<Travel> Travels
        {
            get
            {
                return this.travels;
            }

            set
            {
                this.travels = value;
            }
        }
    }
}
