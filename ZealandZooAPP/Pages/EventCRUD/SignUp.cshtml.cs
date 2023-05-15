using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Exception;
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
        public string  ErrorMessage { get; set; } = null!;

        public SignUpModel(EventRepoService eventRepoService, ParticipantRepoServices participantRepoServices)
        {
            _eventRepoService = eventRepoService;
            _participantRepoServices = participantRepoServices;
        }

        public void OnGet(ParticipantSignUp participantSignUp)
        {
            ParticipantSignUp = participantSignUp;
            ZooEvent = participantSignUp.ZooEvent!;
            try
            {
                if (ParticipantSignUp.ZooEvent != null)
                {
                    if (participantSignUp.ZooEvent.Guests + participantSignUp.Participants <
                        participantSignUp.ZooEvent.MaxGuest)
                    {
                        _participantRepoServices.Create(ParticipantSignUp);
                        participantSignUp.ZooEvent.Guests += participantSignUp.Participants;
                        _eventRepoService.Update(participantSignUp.ZooEvent.Id, participantSignUp.ZooEvent);
                    }
                    else if(participantSignUp.ZooEvent.Guests != participantSignUp.ZooEvent.MaxGuest)
                    {
                        ErrorMessage = $"Der er kun {participantSignUp.ZooEvent.MaxGuest - participantSignUp.ZooEvent.Guests} pladser tilbage.";
                    }
                    else
                    {
                        ErrorMessage = "Der er ikke flere pladser på dette event :-( ...";
                    }
                }

            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ZooException))
                {
                    var zooException = (ZooException)ex;
                    if (zooException.ErrorCode == (ZooErrorCode.SQL_Duplicate_Key))
                    {
                        ErrorMessage = "Du er allerede tilmeldt dette event.";
                    }
                }
                else throw new Exception(ex.StackTrace);
            }
        }
    }
}
