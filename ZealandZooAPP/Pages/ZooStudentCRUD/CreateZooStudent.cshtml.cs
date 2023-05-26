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
        private readonly ZooImageRepoService _imageService;
        public ZooStudentRepoService _zooStudentService;

        public CreateZooStudentModel(IFileService fileService, ZooImageRepoService imageService, ZooStudentRepoService zooStudentService)
        {
            _fileService = fileService;
            _imageService = imageService;
            _zooStudentService = zooStudentService;
        }




        public ZooStudent ZooStudent { get; set; }
        public ZooStudentImage Image { get; set; }


        public string First_Name { get; set; }
        public string Last_Name { get; set; }




        public void OnGet(ZooStudentImage image)
        {
            Image = image;
        }



        public  async Task<IActionResult> OnPost(IFormFile file)
        {
            //UploadImage(file);
            if (file != null)
            {
                Image = _fileService.UploadZoo(file).Result;
                Image.Type = ImageType.ZooStudent;

                _imageService.Create(Image);

                ZooStudent = new ZooStudent();
                ZooStudent.ImageId = Image.Id;
                
            }

            if (ZooStudent != null)
            {
                ZooStudent.First_Name = First_Name; // Assign the value to the First_Name property
                ZooStudent.Last_Name = Last_Name;
                _zooStudentService.Create(ZooStudent);
            }

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
