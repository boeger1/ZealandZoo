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
    {
        _bulletService = service;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Content_Bullet { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        var bullet = new Bullet(Id, Title, Content_Bullet);
        _bulletService.Create(bullet);

        return RedirectToPage("/BulletPage");
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage("/BulletPage");
    }
}