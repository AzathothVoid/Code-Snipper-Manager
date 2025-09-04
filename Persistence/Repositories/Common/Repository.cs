using Application.Contracts.Persistence.Common;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Common
{
    public class Repository<T>: IRepository<T> where T : BaseEntity
    {
        private readonly CodeSnipperManagerDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(CodeSnipperManagerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, ct);

            if (entity == null)
                return;

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> ExistsAsync(T entity)
        {
            var exists = await _dbSet.ContainsAsync(entity);
            return exists ? entity : null!;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync((s => s.Id == id));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
