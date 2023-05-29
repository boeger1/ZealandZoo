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
    private readonly IFileService _locelFileService;
    private readonly ParticipantRepoServices _participantRepoServices;

    /// <summary>
    /// Peter, Mathias: Constructor for DeleteEventModel.
    /// </summary>
    /// <param name="eventRepoService"></param>
    /// <param name="imageRepoService"></param>
    /// <param name="participantRepoServices"></param>
    /// <param name="locelFileService"></param>
    public DeleteEventModel(EventRepoService eventRepoService, ImageRepoService imageRepoService,
        ParticipantRepoServices participantRepoServices, IFileService locelFileService)
    {
        _eventRepoService = eventRepoService;
        _imageRepoService = imageRepoService;
        _participantRepoServices = participantRepoServices;
        _locelFileService = locelFileService;
    }

    [BindProperty] public Event? Event { get; set; }

    public IActionResult OnGet(int id)
    {
        Event = (Event)_eventRepoService.GetById(id);

        return Page();
    }

    /// <summary>
    /// Peter, Mathias: Modtager ID'et på eventet som skal slettes. Sletter også relaterede tilmeldinger og billede.
    /// Efter sletningen er fuldført returneres Calender siden til brugeren.
    /// </summary>
    /// <param name="id">Event ID</param>
    /// <returns></returns>
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

    /// <summary>
    /// Peter: Sletter alle relatede tilmeldinger til det givne event.
    /// </summary>
    /// <param name="eventId">Event ID</param>
    private void DeleteRelatedParticiapent(int eventId)
    {
        var participants = _participantRepoServices.GetByEventId(eventId);

        foreach (var participantSignUp in participants.DistinctBy(p => p.ZooEvent.Id))
        {
            _participantRepoServices.DeleteByEventId(participantSignUp.ZooEvent.Id);
        }
    }

    /// <summary>
    /// Peter: Sletter et billede som er tilknyttet et event fra
    /// filsystemet og fra databasen. 
    /// </summary>
    /// <param name="imageId">Billed ID</param>
    private void DeleteRalatedImage(int imageId)
    {
        var image = (ZooImage)_imageRepoService.GetById(imageId);
        _locelFileService.Delete(image.Name);

        _imageRepoService.Delete(imageId);
    }
}