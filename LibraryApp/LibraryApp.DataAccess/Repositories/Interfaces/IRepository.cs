using LibraryApp.Domain.Models;

namespace LibraryApp.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert (T entity);
        Task Update (T entity);
        Task<int> DeleteById (int id);
    }
}
