using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages;

public class DashboardModel : PageModel
{
    private readonly ILogger<DashboardModel> _logger;


    public BulletRepoService Bullet;

    public EventRepoService Event;


    public DashboardModel(ILogger<DashboardModel> logger, BulletRepoService bullet, EventRepoService _event)
    {
        _logger = logger;
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