using Microsoft.EntityFrameworkCore;
using TeamManagerWeb.Core.Context;
using TeamManagerWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamManagerWeb.Repository.Common
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
       where TEntity : class, IEntity<TKey>
    {
        private readonly ProjectContext _context;

        public Repository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        public async Task CreateAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception($"Couldn't create entity: {ex.Message}");
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception($"Couldn't update entity: {ex.Message}");
            }
        }

        public async Task DeleteAsync(TKey id)
        {
            try
            {
                var entity = await GetAsync(id);
                if (entity != null)
                {
                    _context.Set<TEntity>().Remove(entity);
                    await SaveAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception($"Couldn't delete entity: {ex.Message}");
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception($"Couldn't save changes: {ex.Message}");
            }
        }
    }
}
