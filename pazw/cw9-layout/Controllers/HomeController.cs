using Microsoft.AspNetCore.Mvc;

namespace cw9_layout.Controllers
{
    public class HomeController : Controller
    {
        public List<string> Divisions { get; set; } = new()
        {
            "1A","1B","1kkz87","1D","1E"
        };
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult Form1()
        {
            return View(Divisions);
        }

    }
}
