using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.BulletCRUD
{
    public class CreateBulletModel : PageModel
    {

        private BulletRepoService _bulletService;

        public CreateBulletModel(BulletRepoService service) 
        {
            _bulletService = service;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentBullet { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var bullet = new Bullet(Id, Title, ContentBullet);
            _bulletService.Create(bullet);

            return RedirectToPage("/BulletPage");
        }
    }
}
