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
        public List<BaseModel> GetAll();
        public BaseModel GetById(int id);
        public BaseModel GetByName(string name,BaseModel model);
        public BaseModel Delete(int id);

        public BaseModel DeleteEvent (string name);
        public BaseModel Create(BaseModel model);
        public BaseModel Update(int id, BaseModel model);
        Event GetByName(string name);
    }
}
