using Microsoft.AspNetCore.Mvc.RazorPages;
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

	public Event ZooEvent { get; set; }

	public void OnGet(int id)
	{
		ZooEvent = (Event)_repoService.GetById(id);
	}

    public void OnPostSignUp()
    {
        throw new NotImplementedException();
    }
}