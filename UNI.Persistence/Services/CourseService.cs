using AutoMapper;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;
using UNI.Persistence.Models;
using UNI.Tests.Common.Exceptions;

namespace UNI.Persistence.Services
{
    public class CourseService : ICourseService<CourseModel>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseModel> GetByIdAsync(int id, CancellationToken ct)
        {
            if (id < 1)
                throw new NotFoundException(nameof(CourseModel), id);

            var result = await _courseRepository.GetByIdAsync(id, ct);

            return _mapper.Map<CourseModel>(result);
        }

        public async Task<IEnumerable<CourseModel>> ListAllAsync( CancellationToken ct)
        {
            IEnumerable<Course> course = await _courseRepository.ListAllAsync(ct);
            return _mapper.Map<List<CourseModel>>(course);
        }


        public async Task<CourseModel> AddAsync(CourseModel entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 0)
                throw new NotFoundException(nameof(CourseModel), entity);

            var entityT = _mapper.Map<Course>(entity);
            var result = await _courseRepository.AddAsync(entityT, ct);

            return _mapper.Map<CourseModel>(result);
        }

        public async Task<CourseModel> UpdateAsync(CourseModel entity, CancellationToken ct)
        {

            if (entity == null || entity.Id == null || entity.Id < 1)
                throw new NotFoundException(nameof(CourseModel), entity);

            var entityT = _mapper.Map<Course>(entity);
            var result = await _courseRepository.UpdateAsync(entityT, ct);

            return _mapper.Map<CourseModel>(entity);
        }

        public async Task DeleteAsync(CourseModel entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 1)
                throw new NotFoundException(nameof(CourseModel), entity);

            var entityT = _mapper.Map<Course>(entity);
            await _courseRepository.DeleteAsync(entityT, ct);
        }

        public async Task GetAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseModel>> ListAllAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
