using FakeItEasy;
using FluentAssertions;
using UNI.Domain.Contracts;
using UNI.Persistence.Models;
using UNI.Tests.Common.Exceptions;
using UNI.WebApi.Controllers;
using Xunit;

namespace UNI.Tests.Controllers
{
    public class CourseControllerTests
    {
        private readonly ICourseService<CourseModel> _courseService;

        private static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken cancellationToken = cts.Token;

        public CourseControllerTests()
        {
            _courseService = A.Fake<ICourseService<CourseModel>>();
        }

        [Fact]
        public void CourseController_GetListOfCourses_ReturnOK()
        {
            //Arrange

            var controller = new CoursesController(_courseService);

            //Act
            var result = controller.List(cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void CourseController_CreateCourse_ReturnOK()
        {
            //Arrange

            var courseModel = A.Fake<CourseModel>();
            var controller = new CoursesController(_courseService);

            //Act
            var result = controller.Create(courseModel,cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void CourseController_CreateCourse_ReturnException()
        {
            //Arrange

            var courseModel = A.Fake<CourseModel>();
            courseModel.Id = 0;
            var controller = new CoursesController(_courseService);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.Create(courseModel, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => controller.Create(null, cancellationToken));
        }


        [Fact]
        public void CourseController_EditCourse_ReturnOK()
        {
            //Arrange

            var courseModel = A.Fake<CourseModel>();
            var controller = new CoursesController(_courseService);

            //Act
            var result = controller.Edit(courseModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void CourseController_EditCourse_ReturnException()
        {
            //Arrange

            var courseModel = A.Fake<CourseModel>();
            courseModel.Id = 0;
            var controller = new CoursesController(_courseService);

            //Act
            var result = controller.Edit(courseModel, cancellationToken);

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.Edit(courseModel.Id, cancellationToken));
        }

        [Fact]
        public void CourseController_DeleteCourse_ReturnOK()
        {
            //Arrange

            var courseModel = A.Fake<CourseModel>();
            var controller = new CoursesController(_courseService);

            //Act
            var result = controller.DeleteConfirmed(courseModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void CourseController_DeleteCourse_ReturnException()
        {
            //Arrange

            var courseModel = A.Fake<CourseModel>();
            courseModel.Id = 0;
            var controller = new CoursesController(_courseService);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.Delete(courseModel.Id, cancellationToken));
        }

    }
}
