using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages
{
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
