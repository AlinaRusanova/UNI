using UNI.Domain.Entities;

namespace UNI.Domain.Contracts
{
    public interface ICourseService<M> : IAsyncService<M> where M : class, new()
    {
        Task<IEnumerable<M>> ListAllAsync(CancellationToken ct);
    }
}
