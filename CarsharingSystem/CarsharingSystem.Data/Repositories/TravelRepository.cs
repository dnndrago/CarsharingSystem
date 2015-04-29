
namespace CarsharingSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CarsharingSystem.Model;

    public class TravelRepository : GenericRepository<Travel>
    {
        public TravelRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

    }
}
