
namespace CarsharingSystem.Data.Repositories
{
    using CarsharingSystem.Model;

    public class DrivingLicenseRepository : GenericRepository<DrivingLicense>
    {
        public DrivingLicenseRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
