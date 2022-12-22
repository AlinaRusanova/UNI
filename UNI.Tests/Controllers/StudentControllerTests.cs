using FakeItEasy;
using FluentAssertions;
using UNI.Domain.Contracts;
using UNI.Persistence.Models;
using UNI.Tests.Common.Exceptions;
using UNI.WebApi.Controllers;
using Xunit;

namespace UNI.Tests.Controllers
{
    public class StudentControllerTests
    {
        private readonly IStudentService<StudentModel> _studentService;

        private static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken cancellationToken = cts.Token;

        public StudentControllerTests()
        {
            _studentService = A.Fake<IStudentService<StudentModel>>();
        }

        [Fact]
        public void StudentController_GetListOfStudents_ReturnOK()
        {
            //Arrange
            var id = 1;
            var controller = new StudentsController(_studentService);

            //Act
            var result = controller.List(id, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void StudentController_GetListOfStudents_ReturnException()
        {
            //Arrange
            var id = -1;
            var controller = new StudentsController(_studentService);

            //Act
            var result = controller.List(id, cancellationToken);

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.List(id, cancellationToken));
        }


        [Fact]
        public void StudentController_CreateStudent_ReturnOK()
        {
            //Arrange

            var studentModel = A.Fake<StudentModel>();
            var controller = new StudentsController(_studentService);

            //Act
            var result = controller.Create(studentModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void StudentController_CreateStudent_ReturnException()
        {
            //Arrange

            var studentModel = A.Fake<StudentModel>();
            studentModel.Id = -1;
            var controller = new StudentsController(_studentService);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.Create(studentModel, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => controller.Create(null, cancellationToken));
        }


        [Fact]
        public void StudentController_EditStudent_ReturnOK()
        {
            //Arrange

            var studentModel = A.Fake<StudentModel>();
            var controller = new StudentsController(_studentService);

            //Act
            var result = controller.Edit(studentModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void StudentController_EditStudent_ReturnException()
        {
            //Arrange

            var studentModel = A.Fake<StudentModel>();
            studentModel.Id = 0;
            var controller = new StudentsController(_studentService);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.Edit(studentModel.Id, cancellationToken));
        }


        [Fact]
        public void StudentController_DeleteStudent_ReturnOK()
        {
            //Arrange

            var studentModel = A.Fake<StudentModel>();
            var controller = new StudentsController(_studentService);

            //Act
            var result = controller.DeleteConfirmed(studentModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void StudentController_DeleteStudent_ReturnException()
        {
            //Arrange

            var studentModel = A.Fake<StudentModel>();
            studentModel.Id = 0;
            var controller = new StudentsController(_studentService);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.Delete(studentModel.Id, cancellationToken));
        }

    }
}
