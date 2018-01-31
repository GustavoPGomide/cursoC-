using System.Web.Mvc;

namespace mvc
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}