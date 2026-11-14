using cw8_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw8_mvc.Controllers
{
    public class TimerController : Controller
    {

        // GET: TimerController
        public IActionResult Index()
        {
            var colors = MyColors.Colors();
            return View("Show",colors);
        }

    }
}
