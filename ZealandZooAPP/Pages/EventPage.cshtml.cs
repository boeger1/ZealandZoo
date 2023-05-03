using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages
{
    public class EventPageModel : PageModel
    {

        public Event ZooEvent { get; set; }

        private EventRepoService _repoService;
        public EventPageModel(EventRepoService eventRepoService)
        {
            _repoService = eventRepoService;
        }

        public void OnGet(int id)
        {
            ZooEvent = (Event) _repoService.GetById(id);
        }
    }
}
