
namespace CarsharingSystem.Data.Repositories
{
    using System;
    using System.Linq;

    using CarsharingSystem.Model;

    public class PassengerRepository : GenericRepository<Passenger>
    {
        public PassengerRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
