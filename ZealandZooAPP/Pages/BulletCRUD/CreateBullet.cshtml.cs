using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.BulletCRUD;
/// <summary>
/// Sarah
/// </summary>
[Authorize(Roles = "admin")]
[BindProperties]
public class CreateBulletModel : PageModel
{ 
    private BulletRepoService _bulletService;

    public CreateBulletModel(BulletRepoService service)
    { //henter vores bulletreposervice
        _bulletService = service;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Content_Bullet { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {   //hvis validering ikke lykkes
        if (!ModelState.IsValid) return Page();
        //ved en vellykket validering retuneres en liste af Bullets
        var bullet = new Bullet(Id, Title, Content_Bullet);
        _bulletService.Create(bullet);
        //sideomdirigering
        return RedirectToPage("/BulletPage");
    }

    public IActionResult OnPostCancel()
    {    //ved at trykke fortryd sker der en sideomdirigerin
        return RedirectToPage("/BulletPage");
    }
}