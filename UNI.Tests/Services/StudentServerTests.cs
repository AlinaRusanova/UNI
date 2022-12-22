using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;
using UNI.Persistence.Models;
using UNI.Persistence.Services;
using UNI.Tests.Common.Exceptions;
using Xunit;

namespace UNI.Tests.Services
{
    public class StudentServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        private static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken cancellationToken = cts.Token;

        public StudentServiceTests()
        {
            _studentRepository = A.Fake<IStudentRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void StudentServer_ListOfStudent_ReturnOK()
        {
            //Arrange
            var students = A.Fake<ICollection<StudentModel>>();
            var studentList = A.Fake<List<StudentModel>>();
            A.CallTo(() => _mapper.Map<List<StudentModel>>(students)).Returns(studentList);
            var service = new StudentService(_studentRepository, _mapper);

            //Act
            var result = service.ListAllAsync(1, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void StudentServer_ListOfStudent_ReturnException()
        {
            //Arrange
            var students = A.Fake<ICollection<StudentModel>>();
            var studentList = A.Fake<List<StudentModel>>();
            A.CallTo(() => _mapper.Map<List<StudentModel>>(students)).Returns(studentList);
            var service = new StudentService(_studentRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.ListAllAsync(-1, cancellationToken));
        }



        [Fact]
        public void StudentServer_CreateStudent_ReturnOK()
        {
            //Arrange

            var students = A.Fake<Student>();
            var studentModel = A.Fake<StudentModel>();

            A.CallTo(() => _mapper.Map<Student>(studentModel)).Returns(students);
            var service = new StudentService(_studentRepository, _mapper);

            //Act
            var result = service.AddAsync(studentModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void StudentServer_CreateStudent_ReturnException()
        {
            //Arrange

            var students = A.Fake<Student>();
            var studentModel = A.Fake<StudentModel>();
            students.Id = -2;

            A.CallTo(() => _mapper.Map<Student>(studentModel)).Returns(students);
            var service = new StudentService(_studentRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.AddAsync(studentModel, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => service.AddAsync(null, cancellationToken));
        }



        [Fact]
        public void StudentServer_GetById_ReturnOK()
        {
            //Arrange

            var students = A.Fake<Student>();
            var studentModel = A.Fake<StudentModel>();

            A.CallTo(() => _mapper.Map<Student>(studentModel)).Returns(students);
            var service = new StudentService(_studentRepository, _mapper);

            //Act
            var result = service.GetByIdAsync(studentModel.Id, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void StudentServer_GetById_ReturnException()
        {
            //Arrange

            var students = A.Fake<Student>();
            var studentModel = A.Fake<StudentModel>();
            students.Id = -2;

            A.CallTo(() => _mapper.Map<Student>(studentModel)).Returns(students);
            var service = new StudentService(_studentRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.GetByIdAsync(studentModel.Id, cancellationToken));
        }



        [Fact]
        public void StudentServer_Update_ReturnOK()
        {
            //Arrange

            var students = A.Fake<Student>();
            var studentModel = A.Fake<StudentModel>();

            A.CallTo(() => _mapper.Map<Student>(studentModel)).Returns(students);
            var service = new StudentService(_studentRepository, _mapper);

            //Act
            var result = service.UpdateAsync(studentModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void StudentServer_Update_ReturnException()
        {
            //Arrange

            var students = A.Fake<Student>();
            var studentModel = A.Fake<StudentModel>();
            students.Id = 0;

            A.CallTo(() => _mapper.Map<Student>(studentModel)).Returns(students);
            var service = new StudentService(_studentRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.UpdateAsync(studentModel, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => service.UpdateAsync(null, cancellationToken));
        }

        [Fact]
        public void StudentServer_Delete_ReturnOK()
        {
            //Arrange

            var students = A.Fake<Student>();
            var studentModel = A.Fake<StudentModel>();

            A.CallTo(() => _mapper.Map<Student>(studentModel)).Returns(students);
            var service = new StudentService(_studentRepository, _mapper);

            //Act
            var result = service.DeleteAsync(studentModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void StudentServer_Delete_ReturnException()
        {
            //Arrange

            var students = A.Fake<Student>();
            var studentModel = A.Fake<StudentModel>();
            students.Id = 0;

            A.CallTo(() => _mapper.Map<Student>(studentModel)).Returns(students);
            var service = new StudentService(_studentRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.DeleteAsync(studentModel, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => service.DeleteAsync(null, cancellationToken));
        }

    }
}
