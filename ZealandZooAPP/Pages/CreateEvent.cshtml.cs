using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages
{
    public class CreateEventModel : PageModel
    {
        private EventRepoService _service;

        [BindProperty]
        public Event Event { get; set; }

        public CreateEventModel (EventRepoService service)
        {
            _service = service;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _service.Create(Event);

            return RedirectToPage("/Calender");
        }



    }
}
