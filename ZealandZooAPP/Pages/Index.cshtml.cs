using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public BulletRepoService Bullet;
    public List<BaseModel> Bullets { get; private set; }

    
    public IndexModel(ILogger<IndexModel> logger, BulletRepoService bullet )
    {
        _logger = logger;
        Bullet = bullet;
    }

	public void OnGet()
	{
        Bullets = Bullet.GetAll();
	}

}