
namespace CarsharingSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using CarsharingSystem.Data.Repositories;
    using CarsharingSystem.Model;

    public class CarsharingData : ICarsharingData
    {
        private readonly DbContext context;

        private readonly IDictionary<Type, object> repositories;

        public CarsharingData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Driver> Drivers
        {
            get { return this.GetRepository<Driver>(); }
        }

        public IRepository<Passenger> Passengers
        {
            get { return this.GetRepository<Passenger>(); }
        }

        public IRepository<Travel> Travels
        {
            get { return this.GetRepository<Travel>(); }
        }

        public IRepository<Vehicle> Vehicles
        {
            get { return this.GetRepository<Vehicle>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                //if (type.IsAssignableFrom(typeof(Game)))
                //{
                //    typeOfRepository = typeof(GamesRepository);
                //}

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
