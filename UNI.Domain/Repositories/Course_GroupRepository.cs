using Microsoft.EntityFrameworkCore;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;

namespace UNI.Domain.Repositories
{
    public class Course_GroupRepository : BaseRepository<Course_Group>, ICourse_GroupRepository
    {
        public Course_GroupRepository(UniDbContext dbContext) : base(dbContext) { }
        public async Task<IEnumerable<Course_Group>> ListAllAsync(CancellationToken ct)
        {
            return await _dbContext.Set<Course_Group>()
                .Include(x=>x.Course)
                .Include(x=>x.Group)
                .ToListAsync(ct);
        }


    }
}
