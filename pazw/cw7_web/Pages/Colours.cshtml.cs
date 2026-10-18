using cw7_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7_web.Pages
{
    
    public class ColoursModel : PageModel
    {
        public List<MyColor> Colors { get; set; }
        public void OnGet()
        {
            Colors = FileRepo.GetColors();
        }
    }
}
