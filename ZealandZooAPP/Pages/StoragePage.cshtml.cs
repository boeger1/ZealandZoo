using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZealandZooAPP.Pages
{
    public class StoragePageModel : PageModel
    {

        public IStorageItemRepoService _storageService { get; set; }

      

        public StoragePageModel(IStorageItemRepoService service)
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
