using Microsoft.EntityFrameworkCore;
using MillionAndUp.Data;
using MillionAndUp.Domain.Interfaces;

namespace MillionAndUp.Domain.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<T> _entitySet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entitySet = _context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _entitySet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            T entidad = await _entitySet.FindAsync(id);
            _entitySet.Remove(entidad);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _entitySet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entitySet.ToListAsync();
        }
        public void Update(T entity)
        {
            _entitySet.Update(entity);
            _context.SaveChanges();
        }
    }
}
