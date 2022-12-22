using Microsoft.EntityFrameworkCore;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;
using UNI.Tests.Common.Exceptions;

namespace UNI.Domain.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T>, IDisposable where T : class, IEntity, new()
    {
        protected readonly UniDbContext _dbContext;
        bool _disposed;

        public BaseRepository(UniDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> ListAllAsync(CancellationToken ct)
        {
            return await _dbContext.Set<T>().ToListAsync(ct);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken ct)
        {
            if (id < 1)
                throw new NotFoundException(nameof(T), id); 

            return await _dbContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
          
        }

        public async Task<T> AddAsync(T entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 0)
                throw new NotFoundException(nameof(T), entity);

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync(ct);

            return entity;
        }

        public async Task<T> UpdateAsync( T entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 1)
                throw new NotFoundException(nameof(T), entity);

            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync(ct);
            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 1)
                throw new NotFoundException(nameof(T), entity);

            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(ct);
        }
        public Task GetAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _dbContext.Dispose();

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
