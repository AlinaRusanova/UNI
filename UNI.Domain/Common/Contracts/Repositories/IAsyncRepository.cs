using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNI.Domain.Entities;

namespace UNI.Domain.Contracts
{
    public interface IAsyncRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<T>> ListAllAsync(CancellationToken ct);
        Task<T> AddAsync(T entity, CancellationToken ct);
        Task<T> UpdateAsync( T entity, CancellationToken ct);
        Task DeleteAsync(T entity, CancellationToken ct);
        Task GetAsync(Func<object, bool> value);
    }
}
