using cw7_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw7_web.Pages
{
    
    public class ContactListModel : PageModel
    {
        private FileRepo _repo;
        public List<Contact> Contacts { get; set; }
        public ContactListModel()
        {
            _repo = new FileRepo();
        }
        public void OnGet()
        {
            Contacts = _repo.GetAll();
        }
    }
}
