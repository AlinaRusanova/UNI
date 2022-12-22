using AutoMapper;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;
using UNI.Persistence.Models;
using UNI.Tests.Common.Exceptions;

namespace UNI.Persistence.Services
{
    public class GroupService : IGroupService<GroupModel>
    {
        public readonly IGroupRepository _groupRepository;
        private readonly ICourse_GroupRepository _cgRepository;
        private readonly IMapper _mapper;
        public GroupService(IGroupRepository groupRepository, ICourse_GroupRepository cgRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _cgRepository = cgRepository;
            _mapper = mapper;
        }

        public async Task<GroupModel> GetByIdAsync(int id, CancellationToken ct)
        {
            if (id < 1)
                throw new NotFoundException(nameof(GroupModel), id);

            var result = await _groupRepository.GetByIdAsync(id, ct);

            return _mapper.Map<GroupModel>(result);
        }

        public async Task<IEnumerable<GroupModel>> ListAllAsync(int courseId, CancellationToken ct)
        {
            if (courseId < 0)
                throw new NotFoundException(nameof(GroupModel), courseId);

            IEnumerable<Group> groups = await _groupRepository.ListAllAsync(ct);
            IEnumerable<Course_Group> cg = await _cgRepository.ListAllAsync(ct);

             var groupsWithCourse = cg.Where(c => c.CourseId == courseId).Select(cg => cg.Group).ToList();

            if (courseId == 0)
            {
                return _mapper.Map<List<GroupModel>>(groups);
            
            }

               return _mapper.Map<List<GroupModel>>(groupsWithCourse);
        }


        public async Task<GroupModel> AddAsync(GroupModel entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 0)
                throw new NotFoundException(nameof(GroupModel), entity);

            var entityT = _mapper.Map<Group>(entity);
            var result = await _groupRepository.AddAsync(entityT, ct);

            return _mapper.Map<GroupModel>(result);
        }

        public async Task<GroupModel> UpdateAsync(GroupModel entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 1)
                throw new NotFoundException(nameof(GroupModel), entity);

            var entityT = _mapper.Map<Group>(entity);
            var result = await _groupRepository.UpdateAsync(entityT, ct);

            return _mapper.Map<GroupModel>(entity);
        }

        public async Task DeleteAsync(GroupModel entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 1)
                throw new NotFoundException(nameof(GroupModel), entity);

            var entityT = _mapper.Map<Group>(entity);
            await _groupRepository.DeleteAsync(entityT, ct);
        }

        public async Task GetAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

    }
}
