using FluentAssertions;
using UNI.Domain.Entities;
using UNI.Domain.Repositories;
using UNI.Tests.Common;
using UNI.Tests.Common.Exceptions;
using Xunit;

namespace UNI.Tests.Repositories
{
    public class GroupRepositoryTests
    {
        private UniContextFactory factory = new UniContextFactory();
        private static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken cancellationToken = cts.Token;

        [Fact]
        public async void GroupRepository_GetGroupById_ReturnsGroup()
        {
            //Arrange
            var id = 1;
            var uniContext = await factory.GetDatabaseContext();
            var groupRepository = new GroupRepository(uniContext);

            //Act
            var result = await groupRepository.GetByIdAsync(id, cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Group>();
            result.GroupName.Should().Be(".Net Developer+Node.js");
        }

        [Fact]
        public async void GroupRepository_GetGroupById_ReturnsException()
        {
            //Arrange
            var id = -1;
            var uniContext = await factory.GetDatabaseContext();
            var groupRepository = new GroupRepository(uniContext);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await groupRepository.GetByIdAsync(id, cancellationToken));
        }

        [Fact]
        public async void GroupRepository_ListAllGroups_ReturnsListGroups()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var groupRepository = new GroupRepository(uniContext);

            //Act
            var result = await groupRepository.ListAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(5);
        }

        [Fact]
        public async void GroupRepository_UpdateGroup_ReturnsNewGroup()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var groupRepository = new GroupRepository(uniContext);
            var group = await groupRepository.GetByIdAsync(1, cancellationToken);
            group.GroupName = "C#";

            //Act
            var result = await groupRepository.UpdateAsync(group, cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Group>();
            result.GroupName.Should().Be("C#");
            result.GroupName.Should().NotBe(".Net Developer+Node.js");
        }

        [Fact]
        public async void GroupRepository_UpdateGroup_ReturnsException()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var groupRepository = new GroupRepository(uniContext);
            var group = await groupRepository.GetByIdAsync(1, cancellationToken);
            group.Id = 0;

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await groupRepository.UpdateAsync(group, cancellationToken));
            await Assert.ThrowsAsync<NotFoundException>(async () => await groupRepository.UpdateAsync(null, cancellationToken));
        }


        [Fact]
        public async void GroupRepository_DeleteGroup()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var groupRepository = new GroupRepository(uniContext);
            var group = await groupRepository.GetByIdAsync(1, cancellationToken);

            //Act
            await groupRepository.DeleteAsync(group, cancellationToken);
            var result = await groupRepository.ListAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(4);
        }

        [Fact]
        public async void GroupRepository_DeleteGroup_ReturnException()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var groupRepository = new GroupRepository(uniContext);
            var group = await groupRepository.GetByIdAsync(1, cancellationToken);
            group.Id = -2;

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await groupRepository.DeleteAsync(group, cancellationToken));
            await Assert.ThrowsAsync<NotFoundException>(async () => await groupRepository.DeleteAsync(null, cancellationToken));
        }

        [Fact]
        public async void GroupRepository_CreateGroup()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var groupRepository = new GroupRepository(uniContext);
            var group = new Group { Id = 6, GroupName = "Python Developer+Angular", Speciality = "FullStack Developer" };

            //Act
            await groupRepository.AddAsync(group, cancellationToken);
            var result = await groupRepository.ListAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(6);
        }

        [Fact]
        public async void GroupRepository_CreateGroup_ReturnException()
        {
            //Arrange

            var uniContext = await factory.GetDatabaseContext();
            var groupRepository = new GroupRepository(uniContext);
            var group = new Group { Id = -6, GroupName = "Python Developer+Angular", Speciality = "FullStack Developer" };

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await groupRepository.AddAsync(group, cancellationToken));
            await Assert.ThrowsAsync<NotFoundException>(async () => await groupRepository.AddAsync(null, cancellationToken));
        }
    }
}
