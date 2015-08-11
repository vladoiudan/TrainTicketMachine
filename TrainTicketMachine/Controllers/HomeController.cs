using System.Web.Mvc;

namespace TrainTicketMachine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Train Station Finder";

            return View();
        }
    }
}
