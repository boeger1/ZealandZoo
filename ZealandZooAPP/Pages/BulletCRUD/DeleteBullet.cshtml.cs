using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.BulletCRUD;

[Authorize(Roles = "admin")]
public class DeleteBulletModel : PageModel
{
    private BulletRepoService _bulletService;

    public DeleteBulletModel(BulletRepoService service)
    {
        _bulletService = service;
    }

    public Bullet Bullet { get; set; }

    public void OnGet(int id)
    {
        Bullet = (Bullet)_bulletService.GetById(id);
    }

    public IActionResult OnPostDelete(int id)
    {
        _bulletService.Delete(id);
        return RedirectToPage("/BulletPage");
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage("/BulletPage");
    }
}