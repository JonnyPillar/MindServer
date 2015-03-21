using System.Web.Mvc;

namespace MindServer.Controllers.Web
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}