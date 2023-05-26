using System.Net.Mail;
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
    private readonly SimplyMailService _simplyMailService;
    private readonly StudentRepoService _studentRepoService;
    private readonly ImageRepoService _imageService;
    private readonly EventRepoService _service;

    public CreateEventModel(EventRepoService service, ImageRepoService imageService, IFileService fileService, SimplyMailService simplyMailService, StudentRepoService studentRepoService)
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

    [BindProperty] 
    public Event Event { get; set; }

    [BindProperty] 
    public TimeSpan StartTime { get; set; }

    [BindProperty] 
    public TimeSpan EndTime { get; set; }

    public ZooImage Image { get; set; }

    public void OnGet(ZooImage image)
    {
        Image = image;
    }

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
    /// Peter
    /// </summary>
    /// <param name="zooEvent"></param>
    private void SendNewsLetter(Event zooEvent)
    {
        _studentRepoService.GetStudentsWithNewsletter()
            .ForEach(s => _simplyMailService
                .SendEventNewLetter(zooEvent, s.Email!));
    }

    /// <summary>
    /// Peter
    /// </summary>
    /// <param name="file"></param>
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