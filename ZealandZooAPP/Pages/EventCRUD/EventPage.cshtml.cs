using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Helper;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.EventCRUD;

public class EventPageModel : PageModel
{
    private readonly EventRepoService _repoService;
    private readonly SimplyMailService _simplyMailService;
    private readonly StudentRepoService _studentRepoService;

    public EventPageModel(EventRepoService eventRepoService, StudentRepoService studentRepoService,
        SimplyMailService simplyMailService)
    {
        _repoService = eventRepoService;
        _studentRepoService = studentRepoService;
        _simplyMailService = simplyMailService;
    }

    public Event ZooEvent { get; set; }

    [BindProperty] public bool Newsletter { get; set; } = false;

    /// <summary>
    /// Peter: Opdaterer 'ZooEvent' instansfeltet og gemmer event ID'et TempData.
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
    /// Peter: 
    /// </summary>
    /// <param name="zooEvent"></param>
    /// <returns></returns>
    public RedirectToPageResult OnPost(Event zooEvent)
    {
        ZooEvent = (Event)_repoService.GetById((int)TempData["EventId"]);
        ZooEvent.SignedUpEmail = zooEvent.SignedUpEmail;

        if (!ModelState.IsValid) return RedirectToPage(this);

        var student = GetStudent();
        var signUp = CreateParticipantSignUp(zooEvent, student);

        SubscribeNewsletter(student);

        return RedirectToPage("SignUp", signUp);
    }

    /// <summary>
    ///  Peter: Opretter en og returnere en tilmelding 
    /// </summary>
    /// <param name="zooEvent"></param>
    /// <param name="student"></param>
    /// <returns></returns>
    private ParticipantSignUp CreateParticipantSignUp(Event zooEvent, Student student)
    {
        var signUp = new ParticipantSignUp();
        signUp.JsonZooEvent = ModelHelper.SerializeBaseModel(ZooEvent);
        signUp.JsonStudent = ModelHelper.SerializeBaseModel(student);
        signUp.Participants = zooEvent.Guests;
        return signUp;
    }

    /// <summary>
    /// Peter: Tilmelder en studerende til at
    /// modtager nyhedsbreve og sender en velkomstbrev.
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

    /// <summary>
    /// Henter den studerende ud fra den e-mail addresse som er brugt ved tilmeldingen.
    /// Hvis ingen studerende findes i databasen bliver den oprettet.
    /// </summary>
    /// <returns>Student object</returns>
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


    /// <summary>
    /// Peter: Opretter en studerende i databasen med den e-mail
    /// som er brugt til tilmeldingen.
    /// </summary>
    /// <returns></returns>
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