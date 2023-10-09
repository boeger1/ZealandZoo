using ZealandZooLIB.Models;

namespace ZealandZooLIB.Services;

/// <summary>
///     Peter
/// </summary>
public interface IRepositoryService<t>
{
    public List<t> GetAll();
    public t GetById(int id);
    public t Delete(int id);
    public t Create(t model);
    public t Update(int id, t model);
}