using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooAPP.Services;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.ZooStudentCRUD
{
    [BindProperties]
    public class CreateZooStudentModel : PageModel
    {

        private readonly IFileService _fileService;
        private readonly ImageRepoService _imageService;
        public ZooStudentRepoService _zooStudentService;

        public CreateZooStudentModel(IFileService fileService, ImageRepoService imageService, ZooStudentRepoService zooStudentService)
        {
            _fileService = fileService;
            _imageService = imageService;
            _zooStudentService = zooStudentService;
        }




        public ZooStudent ZooStudent { get; set; }
        public ZooImage Image { get; set; }


        public string First_Name { get; set; }
        public string Last_Name { get; set; }




        public void OnGet(ZooImage image)
        {
            Image = image;
        }



        public  async Task<IActionResult> OnPostZooStudent(IFormFile file)
        {
            if (file != null)
            {
                Image =  await _fileService.Upload(file);
                Image.Type = ImageType.ZooStudent;

                _imageService.Create(Image);

                ZooStudent = new ZooStudent();
                ZooStudent.ImageId = Image.Id;
            }
            _zooStudentService.Create(ZooStudent);

            return RedirectToPage("/About");

        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/About");
        }




    }
}
