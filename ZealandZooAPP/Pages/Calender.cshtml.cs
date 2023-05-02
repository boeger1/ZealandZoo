using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Services;
using ZealandZooLIB.Models;

namespace ZealandZooAPP.Pages
{
    public class CalenderModel : PageModel
    {
        public EventService EventService { get; init; }
        public CalendarService CalendarService { get; init; }

        public List<Event> Events { get; set; }
        public CalenderModel(EventService eventService, CalendarService calendarService )
        {
            EventService = eventService;
            CalendarService = calendarService;
        }

        public void OnGet()
        {
            Events = EventService.GetEvents();
        }

        public void OnPostNextMonth()
        {
            CalendarService.NextMonth();
            Events = EventService.GetEvents();
        }
        
        public void OnPostPreviousMonth()
        {
            CalendarService.PreviousMonth();
            Events = EventService.GetEvents();
        }
        

    }
}
