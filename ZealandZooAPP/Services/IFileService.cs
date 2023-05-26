using ZealandZooLIB.Models;

namespace ZealandZooAPP.Services;

public interface IFileService
{
    public Task<ZooImage> Upload(IFormFile file);
    public bool Delete(string path);
}