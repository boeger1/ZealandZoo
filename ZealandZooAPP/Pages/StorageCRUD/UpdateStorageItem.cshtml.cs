using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.StorageCRUD
{
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
        public string Name { get; set; }


        public ItemType Item_Type { get; set; }

        [Required(ErrorMessage = "Ugyldig pris")]
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            StorageItem StorageItem = new StorageItem
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
}
