using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooAPP.Services;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.EventCRUD;

[Authorize(Roles = "admin")]
public class DeleteEventModel : PageModel
{
    private readonly EventRepoService _eventRepoService;
    private readonly ImageRepoService _imageRepoService;
    private readonly ParticipantRepoServices _participantRepoServices;
    private readonly IFileService _locelFileService;


    public DeleteEventModel(EventRepoService eventRepoService, ImageRepoService imageRepoService, ParticipantRepoServices participantRepoServices, IFileService locelFileService)
    {
        _eventRepoService = eventRepoService;
        _imageRepoService = imageRepoService;
        _participantRepoServices = participantRepoServices;
        _locelFileService = locelFileService;
    }

	[BindProperty] 
	public Event? Event { get; set; }

	public IActionResult OnGet(int id)
	{
		Event = (Event)_eventRepoService.GetById(id);

		return Page();
	}

	public IActionResult OnPost(int id)
	{
		var zooEvent = (Event)_eventRepoService.GetById(id);

        DeleteRelatedParticiapent(id);
        if (zooEvent.ImageId > 0)
        {
            _eventRepoService.Delete(id);
            DeleteRalatedImage(zooEvent.ImageId);
        }
        else
        {
            _eventRepoService.Delete(id);
        }


        return RedirectToPage("/Calender");
	}

    private void DeleteRelatedParticiapent(int eventId)
    {
        List<ParticipantSignUp> participants = _participantRepoServices.GetByEventId(eventId);

        foreach (var participantSignUp in participants.DistinctBy(p => p.ZooEvent.Id))
        {
            _participantRepoServices.DeleteByEventId(participantSignUp.ZooEvent.Id);
        }
    }

    private void DeleteRalatedImage(int imageId)
    {
        EventImage image = (EventImage) _imageRepoService.GetById(imageId);
        _locelFileService.Delete(image.Name);

        _imageRepoService.Delete(imageId);
    }
}