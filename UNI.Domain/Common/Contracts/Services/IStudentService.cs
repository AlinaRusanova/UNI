
namespace UNI.Domain.Contracts
{
    public interface IStudentService<M> : IAsyncService<M> where M : class, new()
    {
    }
}
