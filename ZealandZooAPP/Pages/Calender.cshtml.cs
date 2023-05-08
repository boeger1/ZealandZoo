using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Services;
using ZealandZooLIB.Models;


namespace ZealandZooAPP.Pages
{
    public class CalenderModel : PageModel
    {
        private readonly ImageRepoService _ImageRepoService;
        public EventRepoService EventService { get; init; }
        public CalendarService CalendarService { get; init; }

        public List<BaseModel> Events { get; set; }
        public CalenderModel(EventRepoService eventService, CalendarService calendarService, ImageRepoService imageRepoService )
        {
            _ImageRepoService = imageRepoService;
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

        public string GetEventImageNameById(int id)
        {
            var eventImage = (EventImage)_ImageRepoService.GetById(id);
            return eventImage.Name;
        }
        

    }
}
