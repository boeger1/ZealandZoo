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
                    _participantRepoServices.Create(ParticipantSignUp);
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
