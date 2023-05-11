using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using ZealandZooLIB.Helper;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.EventCRUD;

public class EventPageModel : PageModel
{
	private EventRepoService _repoService;

    public EventPageModel(EventRepoService eventRepoService)
    {
        _repoService = eventRepoService;

    }

    [BindProperty]
    public Event ZooEvent { get; set; }

    public void OnGet(int id)
    {
        if (id > 0)
        {
            ZooEvent = (Event)_repoService.GetById(id);
            TempData["EventId"] = ZooEvent.Id;
        }
        else
        {
            ZooEvent = (Event)_repoService.GetById((int)TempData["EventId"]);
            TempData["EventId"] = ZooEvent.Id;
        }
    }

    public RedirectToPageResult OnPost(Event zooEvent)
    {
        if (ModelState.IsValid)
        {

            ZooEvent = (Event)_repoService.GetById((int)TempData["EventId"]);
            ZooEvent.Guests = zooEvent.Guests;
            ZooEvent.SignedUpEmail = zooEvent.SignedUpEmail;


            return RedirectToPage("SignUp", ZooEvent);
        }

        return RedirectToPage(this);
    }
}
