
namespace CarsharingSystem.WebServices.Controllers
{
    using System;
    using System.Web.Http;

    using CarsharingSystem.Data;
    using CarsharingSystem.WebServices.Models;

    [RoutePrefix("api")]
    public class VehiclesController : ApiController
    {
        private readonly ICarsharingData db;

        public VehiclesController()
            : this(new CarsharingData())
        {   
        }

        public VehiclesController(ICarsharingData data)
        {
            this.db = data;
        }

        // GET api/vechiles/1
        [HttpGet]
        [Route("vehicles/{id}")]
        public IHttpActionResult GetDriverVehicle(string id)
        {
            var vehicle = this.db.Vehicles.Find(new Guid(id));

            if (vehicle == null)
            {
                return this.NotFound();
            }

            var result = new 
            {
                Id = vehicle.Id.ToString(),
                DriverId = vehicle.DriverId.ToString(),
                Manufacturedate = vehicle.ManufactureDate,
                VechileType = vehicle.VehicleType,
                Seats = vehicle.Seats,
                Run = vehicle.Run
            };

            return this.Ok(result);
        }

        // PUT api/vehicles/1
        [Authorize]
        [HttpPut]
        [Route("vehicles/{id}")]
        public IHttpActionResult PutDriverVehicle(VehicleInputModel inputModel, string id)
        {
            var vehicle = this.db.Vehicles.Find(new Guid(id));

            if (vehicle == null)
            {
                return this.NotFound();
            }

            vehicle.ManufactureDate = inputModel.ManufactureDate ?? vehicle.ManufactureDate;
            vehicle.Run = inputModel.Run ?? vehicle.Run;
            vehicle.Seats = inputModel.Seats ?? vehicle.Seats;
            vehicle.VehicleType = inputModel.VehicleType ?? vehicle.VehicleType;

            this.db.SaveChanges();

            return this.Ok(new
            {
                Message = string.Format("Vehicle with id: {0} was modiefied", vehicle.Id)
            });
        }
    }
}
