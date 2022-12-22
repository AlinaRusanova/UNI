

namespace UNI.Domain.Contracts
{
    public interface IGroupService<M> : IAsyncService<M> where M : class, new()
    {
    }
}
