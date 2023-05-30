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
    { //henter den bullet der skal slettes v�rdier vha Id
        Bullet = (Bullet)_bulletService.GetById(id);
    }
    //onpost = n�r siden kaldes/trykkes p�
    public IActionResult OnPostDelete(int id)
    { // Bruger vores delete funktion fra repo
        _bulletService.Delete(id);
        return RedirectToPage("/BulletPage");
    }
    
    public IActionResult OnPostCancel()
    { //sideomdirigering ved fortryd-knappen
        return RedirectToPage("/BulletPage");
    }
}