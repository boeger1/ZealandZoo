using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.StorageCRUD;

public class DeleteStorageItemModel : PageModel
{
    private StorageItemRepoService _storageService;


    public DeleteStorageItemModel(StorageItemRepoService service)
    {
        _storageService = service;
    }


    public StorageItem StorageItem { get; set; }


    public void OnGet(int id)
    {
        StorageItem = (StorageItem)_storageService.GetById(id);
    }


    public IActionResult OnPostDelete(int id)
    {
        _storageService.Delete(id);
        return RedirectToPage("/StoragePage");
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage("/StoragePage");
    }
}