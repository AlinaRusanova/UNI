using FluentAssertions;
using UNI.Domain.Entities;
using UNI.Domain.Repositories;
using UNI.Tests.Common;
using UNI.Tests.Common.Exceptions;
using Xunit;

namespace UNI.Tests.Repositories
{
    public class CourseRepositoryTests
    {
        private UniContextFactory factory = new UniContextFactory();
        private static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken cancellationToken = cts.Token;

        [Fact]
        public async void CourseRepository_GetCourseById_ReturnsCourse()
        {
            //Arrange
            var id = 1;
            var uniContext = await factory.GetDatabaseContext();
            var courseRepository = new CourseRepository(uniContext);

            //Act
            var result = await courseRepository.GetByIdAsync(id, cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Course>();
            result.CourseName.Should().Be(".Net Developer");
        }

        [Fact]
        public async void CourseRepository_GetCourseById_ReturnsException()
        {
            //Arrange
            var id = -1;
            var uniContext = await factory.GetDatabaseContext();
            var courseRepository = new CourseRepository(uniContext);

            //Act

            //Assert

           await Assert.ThrowsAsync<NotFoundException>(async()=> await courseRepository.GetByIdAsync(id,cancellationToken));

        }

        [Fact]
        public async void CourseRepository_ListAllCourse_ReturnsListCourses()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var courseRepository = new CourseRepository(uniContext);

            //Act
            var result = await courseRepository.ListAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(4);
        }

        [Fact]
        public async void CourseRepository_UpdateCourse_ReturnsNewCourses()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var courseRepository = new CourseRepository(uniContext);
            var course = await courseRepository.GetByIdAsync(1,cancellationToken);
            course.CourseName = "C#";

            //Act
            var result = await courseRepository.UpdateAsync(course,cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Course>();
            result.CourseName.Should().Be("C#");
            result.CourseName.Should().NotBe(".Net Developer");
        }

        [Fact]
        public async void CourseRepository_UpdateCourse_ReturnsException()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var courseRepository = new CourseRepository(uniContext);
            var course = await courseRepository.GetByIdAsync(1, cancellationToken);
            course.Id = 0;

            //Act

            //Assert

            await Assert.ThrowsAsync<NotFoundException>(async () => await courseRepository.UpdateAsync(course, cancellationToken));
            await Assert.ThrowsAsync<NotFoundException>(async () => await courseRepository.UpdateAsync(null, cancellationToken));
        }


        [Fact]
        public async void CourseRepository_DeleteCourse()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var courseRepository = new CourseRepository(uniContext);
            var course = await courseRepository.GetByIdAsync(1, cancellationToken);

            //Act
            await courseRepository.DeleteAsync(course, cancellationToken);
            var result = await courseRepository.ListAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(3);
        }

        [Fact]
        public async void CourseRepository_DeleteCourse_ReturnException()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var courseRepository = new CourseRepository(uniContext);
            var course = await courseRepository.GetByIdAsync(1, cancellationToken);
            course.Id = 0;

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await courseRepository.DeleteAsync(course, cancellationToken));
            await Assert.ThrowsAsync<NotFoundException>(async () => await courseRepository.DeleteAsync(null, cancellationToken));
        }

        [Fact]
        public async void CourseRepository_CreateStudent()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var courseRepository = new CourseRepository(uniContext);
            var course = new Course { Id = 5, UrlCoursLogo = "https://gagadget.com/media/post_big/unity-best-tools-january-2022-800x449.jpg", CourseName = "Unity Developer", CourseDescription = "From Complete Beginner To Professional Game Developer. Learn To Code In C# And Create Stunning Games With Unity" };

            //Act
            await courseRepository.AddAsync(course, cancellationToken);
            var result = await courseRepository.ListAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(5);
        }

        [Fact]
        public async void CourseRepository_CreateStudent_ReturnException()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var courseRepository = new CourseRepository(uniContext);
            var course = new Course { Id = 0, UrlCoursLogo = "https://gagadget.com/media/post_big/unity-best-tools-january-2022-800x449.jpg", CourseName = "Unity Developer", CourseDescription = "From Complete Beginner To Professional Game Developer. Learn To Code In C# And Create Stunning Games With Unity" };

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await courseRepository.AddAsync(course, cancellationToken));
            await Assert.ThrowsAsync<NotFoundException>(async () => await courseRepository.AddAsync(null, cancellationToken));
        }
    }
}
