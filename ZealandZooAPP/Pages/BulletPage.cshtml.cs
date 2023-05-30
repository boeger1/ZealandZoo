using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages;

public class BulletPageModel : PageModel
{ /// <summary>
/// sarah
/// </summary>
/// <param name="service">af typen BulletRepoService, g�r det muligt at tilf�je en instans af klassen</param>
    public BulletPageModel(BulletRepoService service)
    { 
        _bulletService = service;
    }

    public BulletRepoService _bulletService { get; set; }

    public List<BaseModel> Bullets { get; set; }
    public Bullet Bullet { get; set; }


    public void OnGet()
    { //retunere en liste af allle bullets
        Bullets = _bulletService.GetAll();
    }
}