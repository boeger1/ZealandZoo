using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.StorageCRUD;

[Authorize(Roles = "admin")]
[BindProperties]
public class UpdateStorageItemModel : PageModel
{
    private StorageItemRepoService _storageService;

    public UpdateStorageItemModel(StorageItemRepoService service)
    {
        _storageService = service;
    }


    public int Id { get; set; }

    [Required(ErrorMessage = "Ugyldigt navn")]
    [StringLength(30, ErrorMessage = "Navn må ikke være længere end 30 tegn")]
    [Display(Name = "Navn")]
    public string Name { get; set; }


    public ItemType Item_Type { get; set; }

    [Required(ErrorMessage = "Pris skal udfyldes")]
    [Range(0.1, double.MaxValue, ErrorMessage = "Prisen skal være et positivt tal")]
    public double Price { get; set; }

    public int Quantity { get; set; }

    public List<ItemType> Item_Types { get; set; }

    public StorageItem UpdateItem { get; set; }


    public void OnGet(int id)
    {
        UpdateItem = (StorageItem)_storageService.GetById(id);

        Item_Types = Enum.GetValues<ItemType>().ToList();

        Name = UpdateItem.Name;
        Item_Type = UpdateItem.Item_Type;
        Price = UpdateItem.Price;
        Quantity = UpdateItem.Quantity;
    }


    public IActionResult OnPostUpdate(int id)
    {
        if (!ModelState.IsValid) return Page();

        var StorageItem = new StorageItem
        {
            Id = id,
            Name = Name,
            Item_Type = Item_Type,
            Price = Price,
            Quantity = Quantity
        };

        _storageService.Update(id, StorageItem);

        return RedirectToPage("/StoragePage");
    }


    public IActionResult OnPostCancel()
    {
        return RedirectToPage("/StoragePage");
    }
}