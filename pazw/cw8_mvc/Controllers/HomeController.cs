using Microsoft.AspNetCore.Mvc;

namespace cw8_mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        public string Info()
        {
            return "To jest informacja";
        }
        public string Date()
        {
            return DateTime.Now.ToShortDateString();
        }

    }
}
