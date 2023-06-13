using Microsoft.Extensions.Configuration;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.Domain.UnitsOfWork
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        readonly IGenericRepository<T> _repo;
        public GenericUnitOfWork(IGenericRepository<T> repo)
        {
            _repo = repo;
        }
        public async Task Add(T model) => await _repo.Add(model);

        public async Task Delete(Guid id) => await _repo.Delete(id);

        public async Task<T> Get(Guid id) => await _repo.Get(id);

        public async Task<IEnumerable<T>> GetAll() => await _repo.GetAll();

        public void Update(T model) => _repo.Update(model);
    }
}
