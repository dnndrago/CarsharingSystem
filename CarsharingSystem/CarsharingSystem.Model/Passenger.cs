
namespace CarsharingSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Passengers")]
    public class Passenger : ApplicationUser
    {
        private ICollection<Travel> travels;

        public Passenger()
        {
            this.travels = new HashSet<Travel>();
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
