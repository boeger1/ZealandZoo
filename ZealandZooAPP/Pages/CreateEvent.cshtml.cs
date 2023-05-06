using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;
using static System.Net.Mime.MediaTypeNames;

namespace ZealandZooAPP.Pages
{
    public class CreateEventModel : PageModel
    {
        private EventRepoService _service;
        private ImageRepoService _imageService;
        private EventImage? _eventImage = null;

        [BindProperty]
        public Event Event { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        public CreateEventModel (EventRepoService service, ImageRepoService imageService)
        {
            _service = service;
            _imageService = imageService;
            Event = new Event();
            Event.DateFrom = DateTime.Now;
            Event.DateTo = DateTime.Now;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostEvent()
        {
            if (_eventImage != null)
            {
                _eventImage.Name = "Img"+Event.Name;

                _imageService.Create(_eventImage);
            }


            _service.Create(Event);

            return RedirectToPage("/Calender");
        }

        public void OnPostImage()
        {
            _eventImage = new EventImage();
            _eventImage.Image = Upload;
        }


    }
}
