using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;


namespace ZealandZooLIB.Services
{
    public class LocalFileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _folderName = "images";
        public LocalFileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<EventImage> Upload(IFormFile file)
        {
            var imageGuid = Guid.NewGuid().ToString();
            var fileName = file.Name + $"{imageGuid}.jpg";
                var filePath = Path.Combine(_environment.WebRootPath, _folderName, fileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);

                EventImage eventImage = new EventImage();
                eventImage.Path = filePath;
                eventImage.Name = fileName;


                return eventImage;
        }

    }
}
