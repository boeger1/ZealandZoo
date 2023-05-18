using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.BulletCRUD;

[Authorize(Roles = "admin")]
[BindProperties]
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
        var updateBullet = (Bullet)_bulletService.GetById(id);

        Title = updateBullet.Title;
        Content_Bullet = updateBullet.Content_Bullet;
    }

    public IActionResult OnPostUpdate(int id)
    {
        if (!ModelState.IsValid) return Page();
        var bullet = new Bullet(Id, Title, Content_Bullet);
        _bulletService.Update(id, bullet);
        return RedirectToPage("/BulletPage");
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage("/BulletPage");
    }
}