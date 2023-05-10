using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages
{
    [Authorize(Roles = "admin")]
    public class StoragePageModel : PageModel
    {

        public StorageItemRepoService _storageService { get; set; }

      

        public StoragePageModel(StorageItemRepoService service)
        {
            _storageService = service;
        }

        public List<BaseModel> StorageItems { get; set; }


        public void OnGet()
        {
            StorageItems = _storageService.GetAll();
        }
    }
}
