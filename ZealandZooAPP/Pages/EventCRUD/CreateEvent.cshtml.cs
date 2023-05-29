using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooAPP.Services;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.EventCRUD;

[Authorize(Roles = "admin")]
public class CreateEventModel : PageModel
{
    private readonly IFileService _fileService;
    private readonly ImageRepoService _imageService;
    private readonly EventRepoService _service;
    private readonly SimplyMailService _simplyMailService;
    private readonly StudentRepoService _studentRepoService;

    public CreateEventModel(EventRepoService service, ImageRepoService imageService, IFileService fileService,
        SimplyMailService simplyMailService, StudentRepoService studentRepoService)
    {
        _service = service;
        _imageService = imageService;
        _fileService = fileService;
        _simplyMailService = simplyMailService;
        _studentRepoService = studentRepoService;

        Event = new Event();
        Event.DateFrom = DateTime.Now;
        Event.DateTo = DateTime.Now;
    }

    [BindProperty] public Event Event { get; set; }

    [BindProperty] public TimeSpan StartTime { get; set; }

    [BindProperty] public TimeSpan EndTime { get; set; }

    public ZooImage Image { get; set; }

    public void OnGet(ZooImage image)
    {
        Image = image;
    }

    /// <summary>
    /// Peter: Receives file posted by the user and open creating an event. The method
    /// precedes to save the image if provided, and persist the created Event object in the database.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public IActionResult OnPostEvent(IFormFile file)
    {
        UploadImage(file);

        Event.DateFrom = Event.DateFrom.Date + StartTime;
        Event.DateTo = Event.DateTo.Date + EndTime;
        _service.Create(Event);

        SendNewsLetter(Event);

        return RedirectToPage("/Calender");
    }

    /// <summary>
    /// Peter: Sends a newsletter to each subscribed student promoting a new event.
    /// </summary>
    /// <param name="zooEvent">Event which details to be shown in the newsletter</param>
    private void SendNewsLetter(Event zooEvent)
    {
        _studentRepoService.GetStudentsWithNewsletter()
            .ForEach(s => _simplyMailService
                .SendEventNewLetter(zooEvent, s.Email!));
    }

    /// <summary>
    ///  Peter: Saves a file the filesystem and creates record in the Image relation
    /// </summary>
    /// <param name="file">File to be uploaded</param>
    private void UploadImage(IFormFile file)
    {
        if (file != null!)
        {
            Image = _fileService.Upload(file).Result;
            
            Image.Type = ImageType.Event;

            _imageService.Create(Image);

            Event.ImageId = Image.Id;
        }
    }
}