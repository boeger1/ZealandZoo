using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

    public async Task<IActionResult> OnPostAsync(int id, int quantity)
    {
        if (!ModelState.IsValid) return Page();


        var item = _storageService.GetById(id) as StorageItem;

        item.Quantity = quantity;

        await _storageService.UpdateAsync(item);

        TempData["message"] = "Quantity of beer has been updated";

        return RedirectToPage();
    }
}