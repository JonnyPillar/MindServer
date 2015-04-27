using System.Web.Mvc;

namespace MindServer.Controllers.Web
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
