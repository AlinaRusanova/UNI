using FakeItEasy;
using FluentAssertions;
using UNI.Domain.Contracts;
using UNI.Persistence.Models;
using UNI.Tests.Common.Exceptions;
using UNI.WebApi.Controllers;
using Xunit;

namespace UNI.Tests.Controllers
{
    public class GroupControllerTests
    {
        private readonly IGroupService<GroupModel> _groupService;

        private static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken cancellationToken = cts.Token;

        public GroupControllerTests()
        {
            _groupService = A.Fake<IGroupService<GroupModel>>();
        }

        [Fact]
        public void GroupController_GetListOfGroups_ReturnOK()
        {
            //Arrange
            var id = 1;
            var controller = new GroupsController(_groupService);

            //Act
            var result = controller.List(id,cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void GroupController_GetListOfGroups_ReturnException()
        {
            //Arrange
            var id = -1;
            var controller = new GroupsController(_groupService);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.List(id, cancellationToken));
        }

        [Fact]
        public void GroupController_CreateGroup_ReturnOK()
        {
            //Arrange

            var groupModel = A.Fake<GroupModel>();
            var controller = new GroupsController(_groupService);

            //Act
            var result = controller.Create(groupModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void GroupController_CreateGroup_ReturnException()
        {
            //Arrange

            var groupModel = A.Fake<GroupModel>();
            groupModel.Id = 0;
            var controller = new GroupsController(_groupService);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.Create(groupModel, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => controller.Create(null, cancellationToken));
        }

        [Fact]
        public void GroupController_EditGroup_ReturnOK()
        {
            //Arrange

            var groupModel = A.Fake<GroupModel>();
            var controller = new GroupsController(_groupService);

            //Act
            var result = controller.Edit(groupModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void GroupController_EditGroup_ReturnException()
        {
            //Arrange

            var groupModel = A.Fake<GroupModel>();
            groupModel.Id= 0;
            var controller = new GroupsController(_groupService);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.Edit(groupModel.Id, cancellationToken));
        }


        [Fact]
        public void GroupController_DeleteGroup_ReturnOK()
        {
            //Arrange

            var groupModel = A.Fake<GroupModel>();
            var controller = new GroupsController(_groupService);

            //Act
            var result = controller.DeleteConfirmed(groupModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void GroupController_DeleteGroup_ReturnException()
        {
            //Arrange

            var groupModel = A.Fake<GroupModel>();
            groupModel.Id = 0;
            var controller = new GroupsController(_groupService);

            //Act
            var result = controller.DeleteConfirmed(groupModel, cancellationToken);

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => controller.Delete(groupModel.Id, cancellationToken));
        }

    }
}
