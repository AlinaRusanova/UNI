using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;
using UNI.Domain.Repositories;
using UNI.Persistence.Models;
using UNI.Persistence.Services;
using UNI.Tests.Common.Exceptions;
using Xunit;

namespace UNI.Tests.Services
{
    public class CourseServiceTests
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        private static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken cancellationToken = cts.Token;

        public CourseServiceTests()
        {
            _courseRepository = A.Fake<ICourseRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void CourseServer_ListOfCourses_ReturnOK()
        {
            //Arrange
            var courses = A.Fake<ICollection<CourseModel>>();
            var coursesList = A.Fake<List<CourseModel>>();
            A.CallTo(() => _mapper.Map<List<CourseModel>>(courses)).Returns(coursesList);
            var service = new CourseService(_courseRepository, _mapper);

            //Act
            var result = service.ListAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void CourseServer_CreateCourse_ReturnOK()
        {
            //Arrange

            var course = A.Fake<Course>();
            var courseModel = A.Fake<CourseModel>();
           
            A.CallTo(() => _mapper.Map<Course>(courseModel)).Returns(course);
            var service = new CourseService(_courseRepository, _mapper);

            //Act
            var result = service.AddAsync(courseModel,cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void CourseServer_CreateCourse_ReturnException()
        {
            //Arrange

            var course = A.Fake<Course>();
            var courseModel = A.Fake<CourseModel>();
            courseModel.Id = -1;

            A.CallTo(() => _mapper.Map<Course>(courseModel)).Returns(course);
            var service = new CourseService(_courseRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() =>  service.AddAsync(null, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => service.AddAsync(courseModel, cancellationToken));

        }

        [Fact]
        public void CourseServer_GetById_ReturnOK()
        {
            //Arrange

            var course = A.Fake<Course>();
            var courseModel = A.Fake<CourseModel>();

            A.CallTo(() => _mapper.Map<Course>(courseModel)).Returns(course);
            var service = new CourseService(_courseRepository, _mapper);

            //Act
            var result = service.GetByIdAsync(courseModel.Id, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void CourseServer_GetById_ReturnException()
        {
            //Arrange

            var course = A.Fake<Course>();
            var courseModel = A.Fake<CourseModel>();
            courseModel.Id = -1;

            A.CallTo(() => _mapper.Map<Course>(courseModel)).Returns(course);
            var service = new CourseService(_courseRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.GetByIdAsync(courseModel.Id, cancellationToken));
        }


        [Fact]
        public void CourseServer_Update_ReturnOK()
        {
            //Arrange

            var course = A.Fake<Course>();
            var courseModel = A.Fake<CourseModel>();

            A.CallTo(() => _mapper.Map<Course>(courseModel)).Returns(course);
            var service = new CourseService(_courseRepository, _mapper);

            //Act
            var result = service.UpdateAsync(courseModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void CourseServer_Update_ReturnException()
        {
            //Arrange

            var course = A.Fake<Course>();
            var courseModel = A.Fake<CourseModel>();
            course.Id = -1;

            A.CallTo(() => _mapper.Map<Course>(courseModel)).Returns(course);
            var service = new CourseService(_courseRepository, _mapper);

            //Act

            //Assert

            Assert.ThrowsAsync<NotFoundException>(() => service.AddAsync(null, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => service.AddAsync(courseModel, cancellationToken));
        }


        [Fact]
        public void CourseServer_Delete_ReturnOK()
        {
            //Arrange

            var course = A.Fake<Course>();
            var courseModel = A.Fake<CourseModel>();

            A.CallTo(() => _mapper.Map<Course>(courseModel)).Returns(course);
            var service = new CourseService(_courseRepository, _mapper);

            //Act
            var result = service.DeleteAsync(courseModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void CourseServer_Delete_ReturnException()
        {
            //Arrange

            var course = A.Fake<Course>();
            var courseModel = A.Fake<CourseModel>();
            courseModel.Id = -1;

            A.CallTo(() => _mapper.Map<Course>(courseModel)).Returns(course);
            var service = new CourseService(_courseRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.AddAsync(null, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => service.AddAsync(courseModel, cancellationToken));
        }

    }
}
