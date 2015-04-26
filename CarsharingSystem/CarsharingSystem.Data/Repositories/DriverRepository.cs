
namespace CarsharingSystem.Data.Repositories
{
    using CarsharingSystem.Model;

    public class DriverRepository : GenericRepository<Driver>
    {
        public DriverRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
