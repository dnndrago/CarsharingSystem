
namespace CarsharingSystem.Data.Repositories
{
    using CarsharingSystem.Model;

    public class VehicleRepository : GenericRepository<Vehicle>
    {
        public VehicleRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
