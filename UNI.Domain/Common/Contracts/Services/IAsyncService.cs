
namespace UNI.Domain.Contracts
{
    public interface IAsyncService<M>
                                        where M : class, new()
    {
        Task<M> GetByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<M>> ListAllAsync(int id, CancellationToken ct);
        Task<M> AddAsync(M entity, CancellationToken ct);
        Task<M> UpdateAsync(M entity, CancellationToken ct);
        Task DeleteAsync(M entity, CancellationToken ct);
        Task GetAsync(Func<object, bool> value);
    }
}
