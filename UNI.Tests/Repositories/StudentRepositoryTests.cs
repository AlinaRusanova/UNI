using FluentAssertions;
using UNI.Domain;
using UNI.Domain.Entities;
using UNI.Domain.Repositories;
using UNI.Tests.Common;
using UNI.Tests.Common.Exceptions;
using Xunit;

namespace UNI.Tests.Repositories
{
    public class StudentRepositoryTests
    {
        private UniContextFactory factory = new UniContextFactory();
        private static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken cancellationToken = cts.Token;

        [Fact]
        public async void StudentRepository_GetStudentById_ReturnsStudent()
        {
            //Arrange
            var id = 1;
            var uniContext = await factory.GetDatabaseContext();
            var studentRepository = new StudentRepository(uniContext);

            //Act
            var result = await studentRepository.GetByIdAsync(id, cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Student>();
            result.LastName.Should().Be("Hejlsberg");
        }

        [Fact]
        public async void StudentRepository_GetStudentById_ReturnsException()
        {
            //Arrange
            var id = -1;
            var uniContext = await factory.GetDatabaseContext();
            var studentRepository = new StudentRepository(uniContext);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await studentRepository.GetByIdAsync(id, cancellationToken));
        }


        [Fact]
        public async void StudentRepository_ListAllStudents_ReturnsListStudents()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var studentRepository = new StudentRepository(uniContext);

            //Act
            var result = await studentRepository.ListAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(5);
        }

        [Fact]
        public async void StudentRepository_UpdateStudent_ReturnsNewStudent()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var studentRepository = new StudentRepository(uniContext);
            var student = await studentRepository.GetByIdAsync(1, cancellationToken);
            student.LastName = "HejlsbergUpd";
            student.ContactInfo.PhoneNumber="11111111111111";

            //Act
            var result = await studentRepository.UpdateAsync(student, cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Student>();
            result.LastName.Should().Be("HejlsbergUpd");
            result.LastName.Should().NotBe("Hejlsberg");
            result.ContactInfo.PhoneNumber.Should().Be("11111111111111");
            result.ContactInfo.PhoneNumber.Should().NotBe("101010101010");
        }

        [Fact]
        public async void StudentRepository_UpdateStudent_ReturnsException()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var studentRepository = new StudentRepository(uniContext);
            var student = await studentRepository.GetByIdAsync(1, cancellationToken);
            student.ContactInfo = null;

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await studentRepository.UpdateAsync(student, cancellationToken));
            await Assert.ThrowsAsync<NotFoundException>(async () => await studentRepository.UpdateAsync(null, cancellationToken));
        }


        [Fact]
        public async void StudentRepository_DeleteStudent()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var studentRepository = new StudentRepository(uniContext);
            var student = await studentRepository.GetByIdAsync(1, cancellationToken);

            //Act
            await studentRepository.DeleteAsync(student, cancellationToken);
            var result = await studentRepository.ListAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(4);
        }

        [Fact]
        public async void StudentRepository_DeleteStudent_ReturnException()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var studentRepository = new StudentRepository(uniContext);
            var student = await studentRepository.GetByIdAsync(1, cancellationToken);
            student.ContactInfo = null;

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await studentRepository.DeleteAsync(student, cancellationToken));
            await Assert.ThrowsAsync<NotFoundException>(async () => await studentRepository.DeleteAsync(null, cancellationToken));
        }

        [Fact]
        public async void StudentRepository_CreateStudent()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var studentRepository = new StudentRepository(uniContext);
            var student = new Student { Id = 6, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1320061631339126786/gHKfzYft_400x400.jpg", FirstName = "David", LastName = "Fowler", GroupId = 2 };
            student.ContactInfo = new ContactInfo { Email = "email", Address = "adress", PhoneNumber = "101010101010", StudentId = 6 };

            //Act
            await studentRepository.AddAsync(student, cancellationToken);
            var result = await studentRepository.ListAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(6);
        }

        [Fact]
        public async void StudentRepository_CreateStudent_ReturnException()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var studentRepository = new StudentRepository(uniContext);
            var student = new Student { Id = -6, UrlStudentPhoto = "https://pbs.twimg.com/profile_images/1320061631339126786/gHKfzYft_400x400.jpg", FirstName = "David", LastName = "Fowler", GroupId = 2 };

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await studentRepository.AddAsync(student, cancellationToken));
            await Assert.ThrowsAsync<NotFoundException>(async () => await studentRepository.AddAsync(null, cancellationToken));
        }
    }
}
