
namespace CarsharingSystem.Data
{
    using CarsharingSystem.Data.Repositories;
    using CarsharingSystem.Model;

    public interface ICarsharingData
    {
        DriverRepository Drivers { get; }

        PassengerRepository Passengers { get; }

        TravelRepository Travels { get; }

        VehicleRepository Vehicles { get; }

        DrivingLicenseRepository DrivingLicenses { get; }

        IRepository<TravelPassenger> TravelPassengers {get; }

        int SaveChanges();
    }
}
