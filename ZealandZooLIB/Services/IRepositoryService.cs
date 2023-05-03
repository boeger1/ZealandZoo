using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.Services
{
    public interface IRepositoryService
    {
        public List<Event> GetAll();
        public BaseModel GetById(int id);
        public BaseModel Delete(int id);
        public BaseModel Create(BaseModel model);
        public BaseModel Update(int id, BaseModel model);
    }
}
