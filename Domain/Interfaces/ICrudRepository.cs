using ContosoUniversity.Domain.Entities.Base;
namespace ContosoUniversity.Domain.Interfaces
{
    public interface ICrudRepository<T> where T : BaseEntity{
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> FindBy(Func<T, bool> filters);
    }
}