namespace MillionAndUp.Domain.Interfaces
{
    public interface IGenericUnitOfWork<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task Add(T model);
        void Update(T model);
        Task Delete(Guid id);
        Task<T> Get(Guid id);
    }
}
