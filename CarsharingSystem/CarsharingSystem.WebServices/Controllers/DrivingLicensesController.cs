
namespace CarsharingSystem.WebServices.Controllers
{
    using System.Web.Http;
    using CarsharingSystem.Data;
    using CarsharingSystem.WebServices.Models;

    [RoutePrefix("api")]
    public class DrivingLicensesController : ApiController
    {
        private readonly ICarsharingData db;

        public DrivingLicensesController()
            : this(new CarsharingData())
        {
        }

        public DrivingLicensesController(ICarsharingData data)
        {
            this.db = data;
        }

        // GET api/DrivingLicenses/1
        [Authorize]
        [HttpGet]
        [Route("DrivingLicenses/{id:int}")]
        public IHttpActionResult GetDriverDrivingLicense(int id)
        {
            var drivingLicense = this.db.DrivingLicenses.Find(id);

            if (drivingLicense == null)
            {
                return this.NotFound();
            }

            var result = new
                {
                    Id = drivingLicense.Id.ToString(),
                    LicenseNumber = drivingLicense.LicenseNumber,
                    ExpiryDate = drivingLicense.ExpiryDate,
                    Categories = drivingLicense.DrivingLicenseCategories
                };

            return this.Ok(result);
        }

        // PUT api/drivinglicenses/1
        [Authorize]
        [HttpPut]
        [Route("DrivingLicenses/{id:int}")]
        public IHttpActionResult PutDriverDrivingLicense(DrivingLicenseInputModel inputModel, int id)
        {
            var drivingLicense = this.db.DrivingLicenses.Find(id);

            if (drivingLicense == null)
            {
                return this.NotFound();
            }

            drivingLicense.LicenseNumber = inputModel.LicenseNumber;
            drivingLicense.ExpiryDate = inputModel.ExpiryDate;
            drivingLicense.DrivingLicenseCategories = inputModel.Categories;

            this.db.SaveChanges();

            return this.Ok(new
                    {
                        Message = string.Format("Driving license with id: {0} was modiefied", drivingLicense.Id)
                    });
        }

        // DELETE api/drivinglicenses/1
        [Authorize]
        [HttpDelete]
        [Route("DrivingLicenses/{id:int}")]
        public IHttpActionResult DeleteDriverDrivingLicense(int id)
        {
            var drivingLicense = this.db.DrivingLicenses.Find(id);

            if (drivingLicense == null)
            {
                return this.NotFound();
            }

            this.db.DrivingLicenses.Delete(drivingLicense);

            this.db.SaveChanges();

            return this.Ok(new
            {
                Message = string.Format("Driving license with id: {0} was deleted", drivingLicense.Id)
            });
        }
    }
}