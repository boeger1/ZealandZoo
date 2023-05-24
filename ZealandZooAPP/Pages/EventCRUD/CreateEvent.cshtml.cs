using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooAPP.Services;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;
using ZealandZooLIB.NewsletterHtml;

namespace ZealandZooAPP.Pages.EventCRUD;

[Authorize(Roles = "admin")]
public class CreateEventModel : PageModel
{
    private readonly IFileService _fileService;
    private readonly SimplyMailService _simplyMailService;
    private readonly ImageRepoService _imageService;
    private readonly EventRepoService _service;

    public CreateEventModel(EventRepoService service, ImageRepoService imageService, IFileService fileService, SimplyMailService simplyMailService)
    {
        _service = service;
        _imageService = imageService;
        _fileService = fileService;
        _simplyMailService = simplyMailService;

        Event = new Event();
        Event.DateFrom = DateTime.Now;
        Event.DateTo = DateTime.Now;
    }

    [BindProperty] public Event Event { get; set; }

    [BindProperty] public TimeSpan StartTime { get; set; }

    [BindProperty] public TimeSpan EndTime { get; set; }

    public EventImage Image { get; set; }

    public void OnGet(EventImage image)
    {
        Image = image;
    }

    public IActionResult OnPostEvent(IFormFile file)
    {
        if (file != null)
        {
            Image = _fileService.Upload(file).Result;
            Image.Type = ImageType.Event;

            _imageService.Create(Image);

            Event.ImageId = Image.Id;
        }

        Event.DateFrom = Event.DateFrom.Date + StartTime;
        Event.DateTo = Event.DateTo.Date + EndTime;
        _service.Create(Event);

        try
        {
            _simplyMailService.Send(new NewEventNewsletter(Event),null);
        } catch (Exception ex) { }

        return RedirectToPage("/Calender");
    }
}