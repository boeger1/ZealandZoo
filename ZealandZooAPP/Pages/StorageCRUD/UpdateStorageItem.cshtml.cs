using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.StorageCRUD
{
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
        public string Name { get; set; }


        public ItemType Item_Type { get; set; }

        [Required(ErrorMessage = "Ugyldig pris")]
        public double Price { get; set; }

        public int Quantity { get; set; }

        public List<ItemType> Item_Types { get; set; }

        public StorageItem StorageItem { get; set; }




        public void OnGet(int id)
        {
            StorageItem updateItem = (StorageItem)_storageService.GetById(id);

            
            Name = updateItem.Name;
            Item_Type = updateItem.Item_Type;
            Price = updateItem.Price;
            Quantity = updateItem.Quantity;
        }





        public IActionResult OnPostUpdate(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            StorageItem item = new StorageItem(Id,Name, Item_Type, Price, Quantity);

            _storageService.Update(id, item);

            return RedirectToPage("/StoragePage");

        }


        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/StoragePage");
        }
    }
}
