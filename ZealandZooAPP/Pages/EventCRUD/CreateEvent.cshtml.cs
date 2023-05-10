using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;
using Microsoft.AspNetCore.Http;
using ZealandZooAPP.Services;
using static System.Net.Mime.MediaTypeNames;

namespace ZealandZooAPP.Pages.EventCRUD
{
    public class CreateEventModel : PageModel
    {
        private readonly EventRepoService _service;
        private readonly ImageRepoService _imageService;
        private readonly IFileService _fileService;

        [BindProperty]
        public Event Event {
            get;
            set; }

        public EventImage Image
        {
            get; 
            set;
        }

        public CreateEventModel (EventRepoService service, ImageRepoService imageService, IFileService fileService)
        {   
            _service = service;
            _imageService = imageService;
            _fileService = fileService;

            Event = new Event();
            Event.DateFrom = DateTime.Now;
            Event.DateTo = DateTime.Now;


        }

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

            _service.Create(Event);


            return RedirectToPage("/Calender");
        }
    }
}
