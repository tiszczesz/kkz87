using Microsoft.AspNetCore.Mvc;

namespace cw8_mvc.Controllers
{
    public class TimerController : Controller
    {
        // GET: TimerController
        public IActionResult Index()
        {
            return View("Show");
        }

    }
}
