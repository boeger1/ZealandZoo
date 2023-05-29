using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooAPP.Services;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.Gallery;

[Authorize(Roles = "admin")]
public class CreateImageModel : PageModel
{
    private readonly ImageRepoService _imageRepoService;
    private readonly IFileService _localFileService;

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
            var Image = _localFileService.Upload(file).Result;

            _imageRepoService.Create(Image);
        }

        return RedirectToPage("Gallery");
    }
}