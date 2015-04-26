using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarsharingSystem.Model;
using CarsharingSystem.Data;

namespace CarsharingSystem.WebServices.Controllers
{
    [RoutePrefix("api")]
    public class DriverController : ApiController
    {
        private readonly ICarsharingData db;

        public DriverController()
            : this(new CarsharingData())
        {   
        }

        public DriverController(ICarsharingData data)
        {
            this.db = data;
        }

        // GET api/Driver
        [Authorize]
        [HttpGet]
        [Route("Drivers")]
        public IHttpActionResult GetDrivers()
        {
            return null;
        }

    //    // GET api/Driver/5
    //    [ResponseType(typeof(Driver))]
    //    public IHttpActionResult GetDriver(string id)
    //    {
    //        Driver driver = db.Users.Find(id);
    //        if (driver == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(driver);
    //    }

    //    // PUT api/Driver/5
    //    public IHttpActionResult PutDriver(string id, Driver driver)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        if (id != driver.Id)
    //        {
    //            return BadRequest();
    //        }

    //        db.Entry(driver).State = EntityState.Modified;

    //        try
    //        {
    //            db.SaveChanges();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!DriverExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return StatusCode(HttpStatusCode.NoContent);
    //    }

    //    // POST api/Driver
    //    [ResponseType(typeof(Driver))]
    //    public IHttpActionResult PostDriver(Driver driver)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        db.Users.Add(driver);

    //        try
    //        {
    //            db.SaveChanges();
    //        }
    //        catch (DbUpdateException)
    //        {
    //            if (DriverExists(driver.Id))
    //            {
    //                return Conflict();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return CreatedAtRoute("DefaultApi", new { id = driver.Id }, driver);
    //    }

    //    // DELETE api/Driver/5
    //    [ResponseType(typeof(Driver))]
    //    public IHttpActionResult DeleteDriver(string id)
    //    {
    //        Driver driver = db.Users.Find(id);
    //        if (driver == null)
    //        {
    //            return NotFound();
    //        }

    //        db.Users.Remove(driver);
    //        db.SaveChanges();

    //        return Ok(driver);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private bool DriverExists(string id)
    //    {
    //        return db.Users.Count(e => e.Id == id) > 0;
    //    }
    }
}