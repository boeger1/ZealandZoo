using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages
{ /// <summary>
/// Sarah har stået for alt der har med bulllets at gøre på denne side
/// </summary>

public class IndexModel : PageModel
{

    public BulletRepoService Bullet;

    public EventRepoService Event;


    public IndexModel(BulletRepoService bullet, EventRepoService _event)
    {
        Bullet = bullet;
        Event = _event;
    }

    public List<BaseModel> Bullets { get; private set; }
    public List<BaseModel> Events { get; set; }


    public void OnGet()
    {
        Bullets = Bullet.GetAll();
        Events = Event.GetAll();
    }
}