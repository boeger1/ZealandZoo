using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.Services
{
    public interface IFileService
    {
       public Task<EventImage> Upload(IFormFile file);
       public bool Delete(string path);
    }
}
