using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZealandZooAPP.Pages
{
    [BindProperties]
    public class CreateStorageItemModel : PageModel    
    {
        private IStorageItemRepoService _storageService;

        public CreateStorageItemModel(IStorageItemRepoService service)
        {
            _storageService = service;
        }

        [Required(ErrorMessage ="Ugyldigt navn")]
        [StringLength(30, ErrorMessage ="Navn må ikke være længere end 30 tegn")]
        public string Name { get; set; }


        public ItemType EnumType { get; set; }

        [Required(ErrorMessage ="Ugyldig pris")]
        public double Price { get; set; }

        public List<ItemType> ItemTypes { get; set; }



        
       public void OnGet()
        {
            ItemTypes = Enum.GetValues<ItemType>().ToList();
        }



        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ItemTypeEnum item = new ItemTypeEnum(Name, EnumType, Price);
            _storageService.Create(item);

            return RedirectToPage("StoragePage");
        }


    }
}
