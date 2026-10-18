using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7_web.Pages
{
    public class IndexModel : PageModel
    {
        public string FirstName { get; set; }
        public void OnGet()
        {
            FirstName = "Alojzy";
        }
    }
}
