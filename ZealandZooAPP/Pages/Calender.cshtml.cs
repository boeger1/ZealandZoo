Susing Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Services;
using ZealandZooLIB.Models;


namespace ZealandZooAPP.Pages
{
    public class CalenderModel : PageModel
    {
        public EventRepoService EventService { get; init; }
        public CalendarService CalendarService { get; init; }

        public List<BaseModel> Events { get; set; }
        public CalenderModel(EventRepoService eventService, CalendarService calendarService )
        {
            EventService = eventService;
            CalendarService = calendarService;

            Events = EventService.GetAll();
        }

        public void OnGet()
        {
            CalendarService.Reset();
        }

        public RedirectResult OnPostCreateEvent()
        {
            return Redirect("CreateEvent");
        }

        public void OnPostNextMonth()
        {
            CalendarService.NextMonth();
            Events = EventService.GetAll();
        }
        
        public void OnPostPreviousMonth()
        {
            CalendarService.PreviousMonth();
            Events = EventService.GetAll();
        }
        

    }
}
