using Microsoft.EntityFrameworkCore;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;
using UNI.Tests.Common.Exceptions;

namespace UNI.Domain.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(UniDbContext dbContext) : base(dbContext) { }


        public async Task<IEnumerable<Student>> ListAllAsync(CancellationToken ct)
        {
            return await _dbContext.Set<Student>()
                .Include(s => s.ContactInfo)
                .Include(s => s.Group)
                .ToListAsync(ct);
        }

        public async Task<Student> GetByIdAsync(int id, CancellationToken ct)
        {
            if (id < 1)
                throw new NotFoundException(nameof(Student), id);

            return await _dbContext.Set<Student>()
                .Include(s => s.ContactInfo)
                .Include(s => s.Group)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Student> AddAsync(Student entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 0 || entity.ContactInfo == null)
                throw new NotFoundException(nameof(Student), entity);

            var entityEntry = _dbContext.Entry<Student>(entity);
            var entityEntryNested = _dbContext.Entry<ContactInfo>(entity.ContactInfo);
            entityEntry.State = EntityState.Added;
            entityEntryNested.State = EntityState.Added;

            await _dbContext.SaveChangesAsync(ct);
            return entity;
        }


        public async Task<Student> UpdateAsync(Student entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 1 || entity.ContactInfo == null)
                throw new NotFoundException(nameof(Student), entity);

            var entityEntry = _dbContext.Entry<Student>(entity);
            var contInfo = _dbContext.Entry<ContactInfo>(entity.ContactInfo);

            entityEntry.State = EntityState.Modified;

            contInfo.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync(ct);
            return entity;
        }

        public async Task DeleteAsync(Student entity, CancellationToken ct)
        {

            if (entity == null || entity.Id < 1 || entity.ContactInfo == null)
                throw new NotFoundException(nameof(Student), entity);

            var entityEntry = _dbContext.Entry<Student>(entity);
            entityEntry.State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync(ct);
        }


    }
}
