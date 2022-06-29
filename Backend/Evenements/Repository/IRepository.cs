using Backend.Evenements.Entities;

namespace Backend.Evenements.Repository
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
         Task<T> GetById(string id);
         Task<IEnumerable<T>> GetAll();
         Task<T> UpdateById(T entity);
         Task<T> DeleteById(int id);
         Task<T> Post(T entity);
    }
}
