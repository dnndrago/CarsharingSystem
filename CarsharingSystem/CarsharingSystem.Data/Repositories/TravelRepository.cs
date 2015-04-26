
namespace CarsharingSystem.Data.Repositories
{
    using CarsharingSystem.Model;

    public class TravelRepository : GenericRepository<Travel>
    {
        public TravelRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
