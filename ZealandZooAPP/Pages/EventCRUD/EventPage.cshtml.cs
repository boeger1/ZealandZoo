using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;


namespace ZealandZooAPP.Pages.EventCRUD
{
    public class EventPageModel : PageModel
    {

        private IRepositoryService _service;

        public EventPageModel(IRepositoryService service)
        {
            _service = service;          
        }


    }
}
