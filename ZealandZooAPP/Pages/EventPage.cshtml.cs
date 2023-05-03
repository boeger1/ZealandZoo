using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;


namespace ZealandZooAPP.Pages
{
    public class EventPageModel : PageModel
    {

        public Event Event1;
        public Event Event2;
        public void OnGet(int id)
        {
            Event1 = new Event();

            Event1.Name = "fest";
            Event1.Describtion = "kom bare du";
            Event1.Price = 100;
            Event1.DateFrom= DateTime.Now;
            Event1.DateTo= DateTime.Now;


            Event2 = new Event();

            Event2.Name = "party";
            Event2.Describtion = "kom til fest";
            Event2.Price = 200;
            Event2.DateFrom = DateTime.Now;
            Event2.DateTo = DateTime.Now;

        }

       



    }
}
