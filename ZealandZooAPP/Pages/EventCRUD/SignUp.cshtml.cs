using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;


namespace ZealandZooAPP.Pages.EventCRUD
{
    public class SignUpModel : PageModel
    {
        private readonly EventRepoService _eventRepoService;
        private readonly ParticipantRepoServices _participantRepoServices;
        public ParticipantSignUp ParticipantSignUp { get; set; } = null!;
        public Event ZooEvent { get; set; } = null!;

        public SignUpModel(EventRepoService eventRepoService, ParticipantRepoServices participantRepoServices)
        {
            _eventRepoService = eventRepoService;
            _participantRepoServices = participantRepoServices;
        }

        public void OnGet(ParticipantSignUp participantSignUp)
        {
            ParticipantSignUp = participantSignUp;

            ZooEvent = participantSignUp.ZooEvent!;

            if (ParticipantSignUp.ZooEvent != null)
                _participantRepoServices.Create(ParticipantSignUp);


            //ZooEvent = (Event)_eventRepoService.Update(zooEvent.Id, zooEvent);
        }
    }
}
