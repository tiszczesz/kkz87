

using cw9_layout.Models;
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
            if (Request.Query.Count != 0)
            {
                string firstname = Request.Query["firstname"];
                string lastname = Request.Query["lastname"];
                string date = Request.Query["birthDate"];
                string division = Request.Query["division"]; 
                var student = new Student
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    BirthDate = date,
                    Division = division,
                };
                ViewBag.Student = student;
                FileRepo.SaveToFile(student);
            }
            return View(Divisions);
        }
        [HttpGet]
        public IActionResult Form2() //przed wypelnieniem formularza
        {
            return View(Divisions);
        }
        [HttpPost]
         public IActionResult Form2(Student student) //po submit
        {
            if (Request.Form.Count > 0)
            {
                string firstname = Request.Form["firstname"];
                string lastname = Request.Form["lastname"];
                string date = Request.Form["birthDate"];
                string division = Request.Form["division"]; 
                var s= new Student
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    BirthDate = date,
                    Division = division,
                };
                ViewBag.Student = s;
                FileRepo.SaveToFile(s);
            }
            return View(Divisions);
            
        }
    }
}


///      loccccccc/home/elo