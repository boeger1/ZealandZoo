using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using ZealandZooLIB.Helper;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.EventCRUD;

public class EventPageModel : PageModel
{
	private readonly EventRepoService _repoService;
    private readonly StudentRepoService _studentRepoService;

    public EventPageModel(EventRepoService eventRepoService, StudentRepoService studentRepoService)
    {
        _repoService = eventRepoService;
        _studentRepoService = studentRepoService;
    }

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
        ZooEvent = (Event)_repoService.GetById((int)TempData["EventId"]);
        ZooEvent.SignedUpEmail = zooEvent.SignedUpEmail;

        if (!ModelState.IsValid) return RedirectToPage(this);

        ParticipantSignUp signUp = new ParticipantSignUp();
        signUp.JsonZooEvent = ModelHelper.SerializeBaseModel(ZooEvent);
        signUp.JsonStudent = ModelHelper.SerializeBaseModel(GetStudent());
        signUp.Participants = zooEvent.Guests;


        return RedirectToPage("SignUp", signUp);

    }

    private Student GetStudent()
    {
        Student student = null!;
        List<BaseModel> students = _studentRepoService.GetAll();
        if (students.Count > 0)
        {
            foreach (Student s in students)
            {
                if (s.Email.Equals(ZooEvent.SignedUpEmail))
                {
                    student = s;
                    return student;
                }
            }
        }

        student = CreateStudent();

        return student;
    }

    private Student CreateStudent()
    {
        Student student = new Student
        {
            Email = ZooEvent.SignedUpEmail
        };

        _studentRepoService.Create(student);


        return student;
    }
}


