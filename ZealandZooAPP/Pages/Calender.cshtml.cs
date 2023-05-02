using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Services;
using ZealandZooLIB.Models;

namespace ZealandZooAPP.Pages
{
    public class CalenderModel : PageModel
    {

        public CalenderModel(EventService eventService) 
        {
            EventService = eventService;


        }

        public EventService EventService { get; private set; }

        public void OnGet()
        {
            //Event event1 = new Event();

            
            //event1.Price = 200;
            //event1.MaxGuest = 100;
            //event1.DateFrom = DateTime.Now;
            //event1.DateTo = DateTime.Now;


            //EventService.CreateEvent(event1);

        }
    }
}
