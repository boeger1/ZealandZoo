using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages;


public class BulletPageModel : PageModel
{
    public BulletPageModel(BulletRepoService service)
    {
        _bulletService = service;
    }

    public BulletRepoService _bulletService { get; set; }

    public List<BaseModel> Bullets { get; set; }
    public Bullet Bullet { get; set; }


    public void OnGet()
    {
        Bullets = _bulletService.GetAll();
    }
}