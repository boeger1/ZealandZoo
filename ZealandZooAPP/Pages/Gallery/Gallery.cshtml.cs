using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.Gallery
{
    public class GalleryModel : PageModel
    {
        private readonly ImageRepoService _imageRepoService;
        public List<BaseModel> Images { get; set; }

        public GalleryModel(ImageRepoService imageRepoService)
        {
            _imageRepoService = imageRepoService;
        }

        public void OnGet()
        {
            Images = _imageRepoService.GetAll();
        }

        public void OnPostDeleteImage(int id)
        {
            _imageRepoService.Delete(id);

            Images = _imageRepoService.GetAll();

        }
    }
}
