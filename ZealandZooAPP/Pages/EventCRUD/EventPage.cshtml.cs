using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Helper;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.EventCRUD;

public class EventPageModel : PageModel
{
    private readonly EventRepoService _repoService;
    private readonly StudentRepoService _studentRepoService;
    private readonly SimplyMailService _simplyMailService;

    public EventPageModel(EventRepoService eventRepoService, StudentRepoService studentRepoService, SimplyMailService simplyMailService)
    {
        _repoService = eventRepoService;
        _studentRepoService = studentRepoService;
        _simplyMailService = simplyMailService;
    }

    public Event ZooEvent { get; set; }

    [BindProperty]
    public bool Newsletter { get; set; } = false;

    /// <summary>
    /// Peter
    /// </summary>
    /// <param name="id"></param>
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

    /// <summary>
    /// Peter
    /// </summary>
    /// <param name="zooEvent"></param>
    /// <returns></returns>
    public RedirectToPageResult OnPost(Event zooEvent)
    {
        ZooEvent = (Event)_repoService.GetById((int)TempData["EventId"]);
        ZooEvent.SignedUpEmail = zooEvent.SignedUpEmail;

        if (!ModelState.IsValid) return RedirectToPage(this);

        var student = GetStudent();
        var signUp = new ParticipantSignUp();
        signUp.JsonZooEvent = ModelHelper.SerializeBaseModel(ZooEvent);
        signUp.JsonStudent = ModelHelper.SerializeBaseModel(student);
        signUp.Participants = zooEvent.Guests;

        SubscribeNewsletter(student);

        return RedirectToPage("SignUp", signUp);
    }

    /// <summary>
    /// Peter
    /// </summary>
    /// <param name="student"></param>
    private void SubscribeNewsletter(Student student)
    {
        if (Newsletter)
        {
            student.Subscribed = true;
            _studentRepoService.NewsLetterSignUp(student);

            _simplyMailService.SendSubscribedLetter(student.Email!);
        }
    }

    private Student GetStudent()
    {
        Student student = null!;
        var students = _studentRepoService.GetAll();
        if (students.Count > 0)
            foreach (Student s in students)
                if (s.Email.Equals(ZooEvent.SignedUpEmail))
                {
                    student = s;
                    return student;
                }

        student = CreateStudent();

        return student;
    }

    private Student CreateStudent()
    {
        var student = new Student
        {
            Email = ZooEvent.SignedUpEmail
        };

        _studentRepoService.Create(student);


        return student;
    }
}
