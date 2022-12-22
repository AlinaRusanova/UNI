using UNI.Domain.Contracts;
using UNI.Domain.Entities;

namespace UNI.Domain.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(UniDbContext dbContext) : base(dbContext) { }
    }
}
