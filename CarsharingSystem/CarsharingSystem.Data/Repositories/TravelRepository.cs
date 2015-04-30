
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


        public IQueryable<Travel> GetTravelsByStartCity(string startPoint)
        {
            return this.Set.Where(t => t.FromDestination == startPoint);
        }

        public IQueryable<Travel> GetTravelsByEndCity(string endPoint)
        {
            return this.Set.Where(t => t.ToDestionation == endPoint);
        }

        public IQueryable<Travel> GetTravelsByDate(DateTime date)
        {
            return this.Set.Where(t => t.TravelDate == date);
        }

    }
}
