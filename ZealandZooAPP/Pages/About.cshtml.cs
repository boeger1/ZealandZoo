using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages;

public class AboutModel : PageModel
{

    //Peter --->
    private readonly ImageRepoService _imageService;
    private readonly SimplyMailService _simplyMailService;
    private readonly StudentRepoService _studentRepoService;

    public AboutModel(StudentRepoService studentRepoService, ImageRepoService imageService,
        SimplyMailService simplyMailService)
    {
        _studentRepoService = studentRepoService;
        _imageService = imageService;
        _simplyMailService = simplyMailService;

        ZooStudents = _studentRepoService.GetAllStudentByType(StudentType.ZooStudent);
    }

    public List<Student> ZooStudents { get; set; }

    [BindProperty] public ContactFormular Formular { get; set; }

    public string GetEventZooStudentImagePathById(int id)
    {
        var image = (ZooImage)_imageService.GetById(id);

        var filePath = image.Path.Replace('\\', '/');
        var pattern = @".*/wwwroot/";
        return Regex.Replace(filePath, pattern, string.Empty);
    }

    public void OnGet()
    {
        ZooStudents = _studentRepoService.GetAllStudentByType(StudentType.ZooStudent);
    }

    public RedirectToPageResult OnPostSubmitFormular()
    {
        _simplyMailService.SendContactLetter(Formular, ZooStudents);

        return RedirectToPage("ContactMailReceit");
    }

    //<--- Peter
}