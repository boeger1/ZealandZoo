using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages;

[Authorize(Roles = "admin")]
public class StoragePageModel : PageModel
{
	public StoragePageModel(StorageItemRepoService service)
	{
		_storageService = service;
	}

	public StorageItemRepoService _storageService { get; set; }

	public List<BaseModel> StorageItems { get; set; }

	public StorageItem StorageItem { get; set; }


	public void OnGet()
	{
		StorageItems = _storageService.GetAll();
	}

	/*public IActionResult OnPostUpdate(int quantity)
	{
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var item = _storageService.FirstOrDefault(x => x.Type == type);
        if (item != null)
        {
            item.Quantity = quantity;
            _storageService.UpdateQuantity();
        }

        return RedirectToPage();
    }
	*/

}