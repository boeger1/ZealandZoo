using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.EventCRUD
{
    [Authorize(policy: "MustBeAdmin")]
    public class DeleteEventModel : PageModel
    {
        private EventRepoService _service;


        [BindProperty]
        public Event? Event { get; set; }

        public DeleteEventModel(EventRepoService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            Event = (Event)_service.GetById(id);

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            _service.Delete(id);

            return RedirectToPage("/Calender");
        }
    }
}
