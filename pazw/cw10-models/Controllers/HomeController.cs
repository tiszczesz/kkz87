using Microsoft.AspNetCore.Mvc;

namespace cw10_models.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
