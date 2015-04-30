
namespace CarsharingSystem.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using CarsharingSystem.Data;
    using CarsharingSystem.Model;
    using CarsharingSystem.WebServices.Models;

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
        public IHttpActionResult PutPassenger(string id, RatingInputModel inputModel)
        {
            var passenger = this.db.Passengers.Find(new Guid(id));

            if (passenger == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.User.Identity.GetUserId();
            var driverToVote = this.db.Drivers.Find(currentUserId);
            var passengerToVote = this.db.Passengers.Find(currentUserId);

            if (driverToVote != null) 
            {
                if (driverToVote.Travels.Any(t => t.Id.ToString() == inputModel.TravelId) == false)
                {
                    this.BadRequest();
                }
            }
            if (passengerToVote != null)
            {
                if (passengerToVote.Travels.Any(t => t.TravelId.ToString() == inputModel.TravelId) == false)
                {
                    this.BadRequest();
                }

                var result = this.db.TravelPassengers
                        .All()
                        .FirstOrDefault(tp => tp.PassengerId == passengerToVote.Id && tp.TravelId.ToString() == inputModel.TravelId);

                if (result != null && result.IsVoted)
                {
                    return this.BadRequest();
                } 
            }

            if (!passenger.Raiting.HasValue)
            {
                passenger.Raiting = inputModel.Rating;
                passenger.Votes = 1;
            }
            else
            {
                var sum = passenger.Raiting.Value * passenger.Votes.Value + inputModel.Rating;

                passenger.Votes += 1;
                passenger.Raiting = sum / passenger.Votes;
            }
            
            return this.Ok(new
                {
                    PassengerId = passenger.Id,
                    Raiting = passenger.Raiting
                });
        }
    }
}