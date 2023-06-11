using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages.BulletCRUD;

[Authorize(Roles = "admin")]
[BindProperties]
public class UpdateBulletModel : PageModel
{ //referere til vores serviceklasse
    private BulletRepoService _bulletService;

   
    public UpdateBulletModel(BulletRepoService service)
    { //kontstruktør der gør det mugeligt bruge instanser af vores service i klassen
        _bulletService = service;
    }

    public int Id { get; set; }

    public string Title { get; set; }
    public string Content_Bullet { get; set; }
    public Bullet Bullet { get; set; }

    public void OnGet(int id)
    { // Denne metode opdatere værdierne i den bullet hvis id svare på det der er blevet kaldt
        Bullet = (Bullet)_bulletService.GetById(id);
        var updateBullet = (Bullet)_bulletService.GetById(id);
        //værdierne der bliver opdateret 
        Title = updateBullet.Title;
        Content_Bullet = updateBullet.Content_Bullet;
    }
    //når der bliver kaldt på siden henter den den bullet der svare til det id den har )
    public IActionResult OnPostUpdate(int id)
    { // hvis modellen ikke kan valideres bliver man omdirigeret til siden man kom fra
        if (!ModelState.IsValid) return Page();
        //opretter en ny instans af Bullet og tilføjer argumenter til konstruktøren
        var bullet = new Bullet(Id, Title, Content_Bullet);
        //tager vores funktion fra repo i brug 
        _bulletService.Update(id, bullet);
        //retunere derefter til BulletPage
        return RedirectToPage("/BulletPage");
    }

    public IActionResult OnPostCancel()
    { //sideomdirigering ved tryk på onPostCancel(knap på html-siden)
        return RedirectToPage("/BulletPage");
    }
}