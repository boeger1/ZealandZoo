using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ZealandZooLIB.Models;
using ZealandZooLIB.Services;

namespace ZealandZooAPP.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public BulletRepoService Bullet;

        public List<BaseModel> Bullets { get; private set; }

        public EventRepoService Event;
        private readonly SimplyMailService _simplyMailService;
        private readonly StudentRepoService _studentRepoService;
        public List<BaseModel> Events { get; set; }


        public IndexModel(ILogger<IndexModel> logger, BulletRepoService bullet, EventRepoService _event, SimplyMailService simplyMailService, StudentRepoService studentRepoService)
        {
             _logger = logger;
            Bullet = bullet;
            Event = _event;
            _simplyMailService = simplyMailService;
            _studentRepoService = studentRepoService;
        }

        

        public void OnGet()
        {
            Bullets = Bullet.GetAll();
            Events = Event.GetAll();
        }

      

    }
}