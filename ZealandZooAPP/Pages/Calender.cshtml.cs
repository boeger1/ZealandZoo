using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages;

public class CalenderModel : PageModel
{
    private readonly ImageRepoService _ImageRepoService;

    public CalenderModel(EventRepoService eventService, CalendarService calendarService,
        ImageRepoService imageRepoService)
    {
        _ImageRepoService = imageRepoService;
        EventService = eventService;
        CalendarService = calendarService;

        Events = EventService.GetAll();
    }

    public EventRepoService EventService { get; init; }
    public CalendarService CalendarService { get; init; }

    public List<BaseModel> Events { get; set; }

    public void OnGet()
    {
        CalendarService.Reset();
    }

    public void OnPostNextMonth()
    {
        CalendarService.NextMonth();
    }

    public void OnPostPreviousMonth()
    {
        CalendarService.PreviousMonth();
    }

    public RedirectResult OnPostCreateEvent()
    {
        return Redirect("/EventCRUD/CreateEvent");
    }


    public string GetEventImageNameById(int id)
    {
        var eventImage = (ZooImage)_ImageRepoService.GetById(id);
        return eventImage.Name;
    }
}