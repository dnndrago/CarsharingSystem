
namespace CarsharingSystem.WebServices.Controllers
{
    using System.Web.Http;

    using CarsharingSystem.Data;
    using CarsharingSystem.Model;

    [RoutePrefix("api")]
    public class PassengersController : ApiController
    {
        private readonly ICarsharingData db;

        public PassengersController()
            : this(new CarsharingData())
        {   
        }

        public PassengersController(ICarsharingData data)
        {
            this.db = data;
        }

        // GET api/Passengers
        [Authorize]
        [HttpGet]
        [Route("passangers")]
        public IHttpActionResult GetPassnagers()
        {
            return null;
        }

        // GET api/Passengers/5
        [Authorize]
        [HttpGet]
        [Route("passangers/{id}")]
        public IHttpActionResult GetPassenger(string id)
        {
            return null;
        }

        // PUT api/Passengers/1/Rating
        [Authorize]
        [HttpPut]
        [Route("passangers/{id}/rating")]
        public IHttpActionResult PutPassenger(string id, Passenger passenger)
        {
            return null;
        }
    }
}