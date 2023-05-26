using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooAPP.Services;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages
{
    public class AboutModel : PageModel
    {
        public ZooStudentRepoService _zooStudentService;
        private readonly ImageRepoService _imageService;
        
        public List<BaseModel> ZooStudents { get; set; }

       
        
        public AboutModel(ZooStudentRepoService zooStudentService, ImageRepoService imageService)
        {
            _imageService = imageService;
            _zooStudentService = zooStudentService;
            
        }



        public string GetEventImageNameById(int id)
        {
            var zooStudentImage = (ZooStudentImage)_imageService.GetById(id);
            return zooStudentImage.Name;
        }



        public void OnGet()
        {
            
            ZooStudents = _zooStudentService.GetAll();
            
        }

       

    }
}
