using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages
{
    public class AboutModel : PageModel
    {
        private readonly StudentRepoService _studentRepoService;
        private readonly ImageRepoService _imageService;
        private readonly SimplyMailService _simplyMailService;

        public List<Student> ZooStudents { get; set; }

        [BindProperty] public ContactFormular Formular { get; set; }

        public AboutModel(StudentRepoService studentRepoService , ImageRepoService imageService, SimplyMailService simplyMailService)
        {
            _studentRepoService = studentRepoService;
            _imageService = imageService;
            _simplyMailService = simplyMailService;

            ZooStudents = _studentRepoService.GetAllStudentByType(StudentType.ZooStudent);

        }



        public string GetEventImageNameById(int id)
        {
            var zooStudentImage = (ZooImage)_imageService.GetById(id);
            return zooStudentImage.Name;
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
    }
}
