
using System.Web.Mvc;

namespace CarsharingSystem.WebServices.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Redirect to Web API Help Page (Documentation)
            return this.Redirect("Help");
        }
    }
}
