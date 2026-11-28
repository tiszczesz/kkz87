using cw10_models.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw10_models.Controllers
{
    public class HomeController : Controller
    {
        private StudentsRepo _repo;
        public HomeController(IConfiguration configuration)
        {
            _repo = new StudentsRepo(configuration);
        }
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var students = _repo.GetStudents();
            return View(students);
        }

    }
}
