using System.Web.Mvc;

namespace TrainTicketMachine.Controllers
{
    public class AngularController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Train Station Finder";

            return View();
        }
    }
}