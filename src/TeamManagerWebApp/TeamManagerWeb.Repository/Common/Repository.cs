using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagerWeb.Core.Context;
using TeamManagerWeb.Core.Entities;

namespace TeamManagerWeb.Repository.Common
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly ProjectContext _context;
       /* private readonly DbSet<TEntity> _dbSet;*/

        public Repository(ProjectContext context)
        {
            _context = context;
            /*_dbSet = _context.Set<TEntity>();*/
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
