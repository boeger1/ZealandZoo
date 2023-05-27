using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooAPP.Services;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages
{
    public class AboutModel : PageModel
    {
        private readonly StudentRepoService _studentRepoService;
        private readonly ImageRepoService _imageService;
        
        public List<BaseModel> ZooStudents { get; set; }

       
        
        public AboutModel(StudentRepoService studentRepoService , ImageRepoService imageService)
        {
            _studentRepoService = studentRepoService;
            _imageService = imageService;
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



    }
}
