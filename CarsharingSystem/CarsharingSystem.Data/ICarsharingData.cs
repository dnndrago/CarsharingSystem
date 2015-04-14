
namespace CarsharingSystem.Data
{
    using CarsharingSystem.Data.Repositories;
    using CarsharingSystem.Model;

    public interface ICarsharingData
    {
        IRepository<Driver> Drivers { get; }

        IRepository<Passenger> Passengers { get; }

        IRepository<Travel> Travels { get; }

        IRepository<Vehicle> Vehicles { get; } 
    }
}
