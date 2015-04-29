
namespace CarsharingSystem.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using CarsharingSystem.Data;
    using CarsharingSystem.Model;
    using CarsharingSystem.WebServices.Models;

    using Microsoft.AspNet.Identity;

    [RoutePrefix("api")]
    public class TravelsController : ApiController
    {
        private readonly ICarsharingData db;

        public TravelsController()
            : this(new CarsharingData())
        {   
        }

        public TravelsController(ICarsharingData data)
        {
            this.db = data;
        }

        // GET api/Travels
        [HttpGet]
        [Route("travels")]
        public IHttpActionResult GetTravels()
        {
            var result =
                this.db.Travels
                .All()
                .OrderByDescending(t => t.TravelDate)
                .Select(
                    t =>
                    new TravelOutputModel
                        {
                            DriverId = t.DriverId.ToString(),
                            VehicleId = t.VehicleId.ToString(),
                            Status = t.Status.ToString(),
                            TravelDate = t.TravelDate,
                            DestinationFrom = t.FromDestination,
                            DestinationTo = t.ToDestionation
                        })
                .ToList();

            return this.Ok(result);
        }

        // GET api/Travels/5
        [HttpGet]
        [Route("travels/{id}")]
        public IHttpActionResult GetTravel(string id)
        {
            var travel = this.db.Travels.Find(new Guid(id));

            if (travel == null)
            {
                return this.NotFound();
            }

            var result = new TravelOutputModel
                {
                    DriverId = travel.DriverId.ToString(),
                    VehicleId = travel.VehicleId.ToString(),
                    Status = travel.Status.ToString(),
                    TravelDate = travel.TravelDate,
                    DestinationFrom = travel.FromDestination,
                    DestinationTo = travel.ToDestionation
                };

            return this.Ok(result);
        }

        // GET api/Travels/5/Passenger
        [HttpGet]
        [Authorize]
        [Route("travels/{id}/passenger")]
        public IHttpActionResult GetAllPassengersByTravel(string id)
        {
            var travel = this.db.Travels.Find(new Guid(id));

            if (travel == null)
            {
                return this.NotFound();
            }

            var result = travel.Passengers.Select(p => new { p.Id, p.UserName, p.Raiting }).ToList();

            return this.Ok(result);
        }

        // POST api/Travels
        [Authorize]
        [HttpPost]
        [Route("travels")]
        public IHttpActionResult PostTravel(TravelInputModel travel)
        {
            if (travel == null)
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var currentDriverId = User.Identity.GetUserId();
            var driver = this.db.Drivers.Find(currentDriverId);

            if (driver == null)
            {
                return this.BadRequest("Driver is requiered.");
            }

            if (driver.Vehicles == null || driver.Vehicles.Count == 0)
            {
                return this.BadRequest("Driver must have at least one vehicle to make a new travel.");
            }

            if (driver.DrivingLicense == null || driver.DrivingLicense.ExpiryDate < DateTime.Now)
            {
                return this.BadRequest("Driver must have a valid driving license.");
            }

            if (!string.IsNullOrWhiteSpace(travel.VehicleId))
            {
                var vehicle = this.db.Vehicles.Find(travel.VehicleId);
                if (!driver.Vehicles.Contains(vehicle))
                {
                    return this.BadRequest();
                }
            }

            var travelToBeAdded = new Travel
                                          {
                                              Driver = driver,
                                              VehicleId = string.IsNullOrWhiteSpace(travel.VehicleId)
                                                              ? driver.Vehicles.FirstOrDefault().Id
                                                              : new Guid(travel.VehicleId),
                                              Status = TravelStatus.Active,
                                              FromDestination = travel.DestinationFrom,
                                              ToDestionation = travel.DestinationTo,
                                              TravelDate = travel.TravelDate.Value
                                          };

            driver.Travels.Add(travelToBeAdded);

            this.db.Travels.Add(travelToBeAdded);

            this.db.SaveChanges();

            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "travels", id = travelToBeAdded.Id },
                new { Id = travelToBeAdded.Id, DriverId = currentDriverId, Message = "Added a new travelModel." });
        }

        // PUT api/Travels/5
        [Authorize]
        [HttpPut]
        [Route("travels/{id}")]
        public IHttpActionResult PutTravel(string id, TravelInputModel travelModel)
        {
            if (travelModel == null)
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var travelToBeUpdated = this.db.Travels.Find(new Guid(id));

            if (travelToBeUpdated == null)
            {
                return this.NotFound();
            }

            travelToBeUpdated.FromDestination = travelModel.DestinationFrom ?? travelToBeUpdated.FromDestination;
            travelToBeUpdated.ToDestionation = travelModel.DestinationTo ?? travelToBeUpdated.ToDestionation;
            travelToBeUpdated.VehicleId = (travelModel.VehicleId == null) ? travelToBeUpdated.VehicleId : new Guid(travelModel.VehicleId);
            travelToBeUpdated.Status = travelModel.TravelStatus ?? travelToBeUpdated.Status;
            travelToBeUpdated.TravelDate = travelModel.TravelDate ?? travelToBeUpdated.TravelDate;

            this.db.SaveChanges();

            return
                this.Ok(
                    new
                        {
                            Id = travelToBeUpdated.Id,
                            DriverId = travelToBeUpdated.DriverId,
                            Message = string.Format("Travel with id: {0} was modified.", id)
                        });
        }

        // PUT api/Travels/5/Passenger
        [Authorize]
        [HttpPut]
        [Route("travels/{id}/passenger")]
        public IHttpActionResult PutTravel(string id)
        {
            var travel = this.db.Travels.Find(new Guid(id));

            if (travel == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.User.Identity.GetUserId();
            var passenger = this.db.Passengers.Find(currentUserId);

            if (passenger == null)
            {
                return this.NotFound();
            }

            if (travel.Passengers.Contains(passenger))
            {
                return this.BadRequest("Cannot add a passenger multiple times to a single travelModel.");
            }

            travel.Passengers.Add(passenger);

            this.db.SaveChanges();

            var result = new
            {
                TravelId = travel.Id.ToString(),
                PassengerId = passenger.Id,
            };

            return this.Ok(result);
        }


        // DELETE api/Travels/5
        [Authorize]
        [HttpDelete]
        [Route("travels/{id}")]
        public IHttpActionResult DeleteTravel(string id)
        {
            var travel = this.db.Travels.Find(new Guid(id));

            if (travel == null)
            {
                return this.NotFound();
            }

            this.db.Travels.Delete(travel);

            this.db.SaveChanges();

            return this.Ok(new { Message = string.Format("Travel with id: {0} was deleted.", id) });
        }
    }
}