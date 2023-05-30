using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages;
/// <summary>
/// Peter
/// </summary>
public class CalenderModel : PageModel
{
    private readonly ImageRepoService _ImageRepoService;

    /// <summary>
    /// Peter
    /// </summary>
    /// <param name="eventService"></param>
    /// <param name="calendarService"></param>
    /// <param name="imageRepoService"></param>
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

    /// <summary>
    /// Peter
    /// </summary>
    public void OnGet()
    {
        CalendarService.Reset();
    }

    /// <summary>
    /// Peter
    /// </summary>
    public void OnPostNextMonth()
    {
        CalendarService.NextMonth();
    }

    /// <summary>
    /// Peter
    /// </summary>
    public void OnPostPreviousMonth()
    {
        CalendarService.PreviousMonth();
    }

    /// <summary>
    /// Peter
    /// </summary>
    /// <returns></returns>
    public RedirectResult OnPostCreateEvent()
    {
        return Redirect("/EventCRUD/CreateEvent");
    }

    /// <summary>
    /// Peter
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public string GetEventImageNameById(int id)
    {
        var eventImage = (ZooImage)_ImageRepoService.GetById(id);
        return eventImage.Name;
    }
}