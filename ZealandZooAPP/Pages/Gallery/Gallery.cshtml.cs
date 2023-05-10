using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooAPP.Services;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.Gallery
{
    public class GalleryModel : PageModel
    {
        private readonly ImageRepoService _imageRepoService;
        private readonly IFileService _localFileService;
        public List<BaseModel> Images { get; set; }

        public GalleryModel(ImageRepoService imageRepoService, IFileService localFileService )
        {
            _imageRepoService = imageRepoService;
            _localFileService = localFileService;
        }

        public void OnGet()
        {
            Images = _imageRepoService.GetAll();
        }

        public void OnPostDeleteImage(int id)
        {
            EventImage imageToBeDeleted = (EventImage)_imageRepoService.GetById(id);

            if (_localFileService.Delete(imageToBeDeleted.Name))
            {
                _imageRepoService.Delete(id);
            }

            Images = _imageRepoService.GetAll();

        }
    }
}
