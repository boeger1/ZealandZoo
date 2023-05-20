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
        public List<BaseModel> Events { get; set; }



        public IndexModel(ILogger<IndexModel> logger, BulletRepoService bullet, EventRepoService _event)
        {
            _logger = logger;
            Bullet = bullet;
            Event = _event;

           

        }

        

        public void OnGet()
        {
            Bullets = Bullet.GetAll();
            Events = Event.GetAll();
        }

        public string GetShortenedContent(string content, int maxLines)
        {
            var lines = content.Split('\n');
            var shortenedContent = string.Join('\n', lines.Take(maxLines));
            return shortenedContent;
        }

    }
}