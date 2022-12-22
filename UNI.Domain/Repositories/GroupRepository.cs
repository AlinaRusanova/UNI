using Microsoft.EntityFrameworkCore;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;
using UNI.Tests.Common.Exceptions;

namespace UNI.Domain.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(UniDbContext dbContext) : base(dbContext)  { }

        public async Task<Group> GetByIdAsync(int id, CancellationToken ct)
        {
            if ( id < 1)
                throw new NotFoundException(nameof(Group), id);
            return await _dbContext.Set<Group>().Include(g => g.ListOfStudents).FirstOrDefaultAsync(n => n.Id == id);
        }

    }
}
