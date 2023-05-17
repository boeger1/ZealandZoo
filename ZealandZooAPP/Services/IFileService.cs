using ZealandZooLIB.Models;

namespace ZealandZooAPP.Services;

public interface IFileService
{
    public Task<EventImage> Upload(IFormFile file);
    public bool Delete(string path);
}