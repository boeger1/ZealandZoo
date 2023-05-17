using ZealandZooLIB.Models;

namespace ZealandZooAPP.Services;

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

        var eventImage = new EventImage();
        eventImage.Path = filePath;
        eventImage.Name = fileName;


        return eventImage;
    }

    public bool Delete(string fileName)
    {
        var filePath = Path.Combine(_environment.WebRootPath, _folderName);
        try
        {
            if (File.Exists(Path.Combine(filePath, fileName)))
            {
                File.Delete(Path.Combine(filePath, fileName));
                Console.WriteLine("File deleted.");
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
        catch (IOException ioExp)
        {
            Console.WriteLine(ioExp.Message);
            return false;
        }

        return true;
    }
}