using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Services;
using ZealandZooLIB.Models;

namespace ZealandZooAPP.Pages.BulletCRUD
{
    public class UpdateBulletModel : PageModel
    {
        private BulletRepoService _bulletService;

        public UpdateBulletModel(BulletRepoService service)
        {
            _bulletService = service;
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string Content_Bullet { get; set; }
        public Bullet Bullet { get; set; }
        public void OnGet(int id)
        {
            Bullet updateBullet = (Bullet)_bulletService.GetById(id);

            Title= updateBullet.Title;
            Content_Bullet = updateBullet.Content_Bullet;
        }

        public IActionResult OnPostUpdate(int id)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            Bullet bullet = new Bullet(Id, Title, Content_Bullet);
            _bulletService.Update(id, bullet);
            return RedirectToPage("/BulletPage");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/BulletPage");
        }
    }
}
