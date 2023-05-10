using ZealandZooLIB.Models;

namespace ZealandZooLIB.Services;

public interface IRepositoryService
{
	public List<BaseModel> GetAll();
	public BaseModel GetById(int id);
	public BaseModel Delete(int id);
	public BaseModel Create(BaseModel model);
	public BaseModel Update(int id, BaseModel model);
}