using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ZealandZooAPP.Services;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;
using static System.Net.Mime.MediaTypeNames;

namespace ZealandZooAPP.Pages.Gallery
{
    public class CreateImageModel : PageModel
    {
        private readonly IFileService _localFileService;
        private readonly ImageRepoService _imageRepoService;

        public CreateImageModel(IFileService localFileService, ImageRepoService imageRepoService)
        {
            _localFileService = localFileService;
            _imageRepoService = imageRepoService;
        }

        public void OnGet()
        {

        }

        public RedirectToPageResult OnPost(IFormFile? file)
        {
            if (file != null)
            {
                EventImage Image = _localFileService.Upload(file).Result;

                _imageRepoService.Create(Image);

            }

            return RedirectToPage("Gallery");
        }
    }
}
