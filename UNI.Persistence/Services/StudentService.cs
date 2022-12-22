using AutoMapper;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;
using UNI.Persistence.Models;
using UNI.Tests.Common.Exceptions;

namespace UNI.Persistence.Services
{
    public class StudentService : IStudentService<StudentModel>
    {
        public readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentModel> GetByIdAsync(int id, CancellationToken ct)
        {
            if ( id < 1)
                throw new NotFoundException(nameof(StudentModel), id);

            var result = await _studentRepository.GetByIdAsync(id, ct);

            return _mapper.Map<StudentModel>(result);
        }
        public async Task<IEnumerable<StudentModel>> ListAllAsync(int id, CancellationToken ct)
        {
            if (id < 0)
                throw new NotFoundException(nameof(StudentModel), id);

            IEnumerable<Student> student = await _studentRepository.ListAllAsync(ct);

            var studentsInGroup = student.Where(c => c.GroupId == id).ToList();

            if (id == 0)
            {
                return _mapper.Map<List<StudentModel>>(student);

            }

            return _mapper.Map<List<StudentModel>>(studentsInGroup);
        }

        public async Task<StudentModel> AddAsync(StudentModel entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 0)
                throw new NotFoundException(nameof(StudentModel), entity);

            var entityT = _mapper.Map<Student>(entity);
            var result = await _studentRepository.AddAsync(entityT, ct);

            return _mapper.Map<StudentModel>(result);
        }

        public async Task<StudentModel> UpdateAsync(StudentModel entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 1)
                throw new NotFoundException(nameof(StudentModel), entity);

            var updRecord = _mapper.Map<Student>(entity);
            updRecord.ContactInfo.StudentId = entity.Id;

            var result = await _studentRepository.UpdateAsync(updRecord, ct);

            return _mapper.Map<StudentModel>(result);
        }

        public async Task DeleteAsync(StudentModel entity, CancellationToken ct)
        {
            if (entity == null || entity.Id < 1)
                throw new NotFoundException(nameof(StudentModel), entity);

            var entityT = _mapper.Map<Student>(entity);
            await _studentRepository.DeleteAsync(entityT, ct);
        }            

        public Task GetAsync(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}