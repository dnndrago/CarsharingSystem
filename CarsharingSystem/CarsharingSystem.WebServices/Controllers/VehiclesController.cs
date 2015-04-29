
namespace CarsharingSystem.WebServices.Controllers
{
    using System.Web.Http;

    using CarsharingSystem.Data;

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
            var vehicle = this.db.Vehicles.Find(id);

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
    }
}
