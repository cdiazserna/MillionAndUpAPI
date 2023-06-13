using MillionAndUp.Models;

namespace MillionAndUp.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Delete(Guid id);
        void Update(T entity);
        Task<List<T>> ExcecuteStoreProcedure<T>(
                string procedure,
                List<ExecuteParameter> objectParameters
                );


    }
}
