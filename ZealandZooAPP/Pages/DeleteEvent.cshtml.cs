using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.Shared
{
    public class DeleteEventModel : PageModel
    {
        private IRepositoryService _service;


        [BindProperty]
        public Event Event { get; set; }

        public DeleteEventModel (IRepositoryService service)
        {
            _service = service;
        }

        public IActionResult OnGet(string Name)
        {
            Event = _service.GetByName(Name);

            return Page();
        }

        public IActionResult OnPost(string Name)
        {
            _service.DeleteEvent(Name);

            return RedirectToPage("/Calender");
        }
    }
}
