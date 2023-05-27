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
        private readonly StudentRepoService _studentRepoService;

        public CreateZooStudentModel(IFileService fileService, ImageRepoService imageService, StudentRepoService studentRepoService)
        {
            _fileService = fileService;
            _imageService = imageService;
            _studentRepoService = studentRepoService;
        }




        public Student ZooStudent { get; set; }
        public ZooImage Image { get; set; }

        public void OnGet(ZooImage image)
        {
            Image = image;
        }



        public  async Task<IActionResult> OnPost(IFormFile file)
        {
            //UploadImage(file);
            if (file != null)
            {
                Image =  await _fileService.Upload(file);
                Image.Type = ImageType.ZooStudent;

                _imageService.Create(Image);

                ZooStudent.ImageId = Image.Id;
                ZooStudent.StudentType = StudentType.ZooStudent;
            }
            _studentRepoService.Create(ZooStudent);

            return RedirectToPage("/About");

        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/About");
        }

        //private void UploadImage(IFormFile file)
        //{
        //    if (file != null)
        //    {
        //        Image = _fileService.UploadZoo(file).Result;
        //        Image.Type = ImageType.ZooStudent;

        //        _imageService.Create(Image);

        //        ZooStudent = new ZooStudent();
        //        ZooStudent.ImageId = Image.Id;
        //        ZooStudent.First_Name = First_Name; // Assign other properties as needed
        //        ZooStudent.Last_Name = Last_Name;
        //    }
        //}


    }
}
