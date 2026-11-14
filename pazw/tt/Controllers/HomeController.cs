using Microsoft.AspNetCore.Mvc;
using tt.Models;

namespace tt.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            var colors = MyColors.Colors();
            return View(colors);
        }

    }
}
