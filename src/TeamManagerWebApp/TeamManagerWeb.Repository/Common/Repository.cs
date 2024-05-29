using Microsoft.EntityFrameworkCore;
using TeamManagerWeb.Core.Context;

namespace TeamManagerWeb.Repository.Common
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly ProjectContext _context;

        public Repository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
