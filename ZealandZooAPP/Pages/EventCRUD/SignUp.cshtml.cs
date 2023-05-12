using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Helper;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;


namespace ZealandZooAPP.Pages.EventCRUD
{
    public class SignUpModel : PageModel
    {
        private readonly EventRepoService _eventRepoService;
        public Event ZooEvent { get; set; }
        public SignUpModel(EventRepoService eventRepoService)
        {
            _eventRepoService = eventRepoService;
        }

        public void OnGet(Event zooEvent)
        {
            ZooEvent = (Event)_eventRepoService.Update(zooEvent.Id, zooEvent);
             
        }
    }
}
