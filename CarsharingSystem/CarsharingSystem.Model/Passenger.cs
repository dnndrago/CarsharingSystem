
namespace CarsharingSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Passengers")]
    public class Passenger : ApplicationUser
    {
        private ICollection<TravelPassenger> travels;

        public Passenger()
        {
            this.travels = new HashSet<TravelPassenger>();
        }

        public virtual ICollection<TravelPassenger> Travels
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
