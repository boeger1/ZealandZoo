using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.StorageCRUD;

[Authorize(Roles = "admin")]
[BindProperties]
public class CreateStorageItemModel : PageModel
{
    private StorageItemRepoService _storageService;


    public CreateStorageItemModel(StorageItemRepoService service)
    {
        _storageService = service;
    }


    [Required(ErrorMessage = "Ugyldigt navn")]
    [StringLength(30, ErrorMessage = "Navn m� ikke v�re l�ngere end 30 tegn")]
    [Display(Name = "Navn")]
    public string Name { get; set; }

    public ItemType Item_Type { get; set; }

    [Required(ErrorMessage = "Pris skal udfyldes")]
    [Range(0.1, double.MaxValue, ErrorMessage = "Prisen skal v�re et positivt tal")]
    public double Price { get; set; }

    public int Quantity { get; set; }

    public int Id { get; set; }

    public List<ItemType> Item_Types { get; set; }


    public void OnGet()
    {
        GetItemTypes();
    }


    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            GetItemTypes();
            return Page();
        }
            
        var item = new StorageItem(Id, Name, Item_Type, Price, Quantity);
        _storageService.Create(item);

		return RedirectToPage("/StoragePage");
	}

    public IActionResult OnPostCancel()
    {
        return RedirectToPage("/StoragePage");
    }


    private void GetItemTypes()
    {
        Item_Types = Enum.GetValues<ItemType>().ToList();
    }


}