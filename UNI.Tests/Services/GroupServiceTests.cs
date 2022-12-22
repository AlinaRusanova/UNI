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
    public class GroupServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly ICourse_GroupRepository _cgRepository;

        private static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken cancellationToken = cts.Token;

        public GroupServiceTests()
        {
            _groupRepository = A.Fake<IGroupRepository>();
            _mapper = A.Fake<IMapper>();
            _cgRepository = A.Fake<ICourse_GroupRepository>();
        }

        [Fact]
        public void GroupServer_ListOfGroups_ReturnOK()
        {
            //Arrange
            var groups = A.Fake<ICollection<GroupModel>>();
            var groupsList = A.Fake<List<GroupModel>>();
            A.CallTo(() => _mapper.Map<List<GroupModel>>(groups)).Returns(groupsList);
            var service = new GroupService(_groupRepository,_cgRepository, _mapper);

            //Act
            var result = service.ListAllAsync(1, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void GroupServer_ListOfGroups_ReturnException()
        {
            //Arrange
            var groups = A.Fake<ICollection<GroupModel>>();
            var groupsList = A.Fake<List<GroupModel>>();
            A.CallTo(() => _mapper.Map<List<GroupModel>>(groups)).Returns(groupsList);
            var service = new GroupService(_groupRepository, _cgRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.ListAllAsync(-1, cancellationToken));

        }


        [Fact]
        public void GroupServer_CreateCourse_ReturnOK()
        {
            //Arrange

            var groups = A.Fake<Group>();
            var groupModel = A.Fake<GroupModel>();

            A.CallTo(() => _mapper.Map<Group>(groupModel)).Returns(groups);
            var service = new GroupService(_groupRepository, _cgRepository, _mapper);

            //Act
            var result = service.AddAsync(groupModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void GroupServer_CreateCourse_ReturnException()
        {
            //Arrange

            var groups = A.Fake<Group>();
            var groupModel = A.Fake<GroupModel>();
            groups.Id = -1;

            A.CallTo(() => _mapper.Map<Group>(groupModel)).Returns(groups);
            var service = new GroupService(_groupRepository, _cgRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.AddAsync(groupModel, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => service.AddAsync(null, cancellationToken));
        }

        [Fact]
        public void GroupServer_GetById_ReturnOK()
        {
            //Arrange

            var groups = A.Fake<Group>();
            var groupModel = A.Fake<GroupModel>();

            A.CallTo(() => _mapper.Map<Group>(groupModel)).Returns(groups);
            var service = new GroupService(_groupRepository, _cgRepository, _mapper);

            //Act
            var result = service.GetByIdAsync(groupModel.Id, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void GroupServer_GetById_ReturnException()
        {
            //Arrange

            var groups = A.Fake<Group>();
            var groupModel = A.Fake<GroupModel>();
            groups.Id = 0;

            A.CallTo(() => _mapper.Map<Group>(groupModel)).Returns(groups);
            var service = new GroupService(_groupRepository, _cgRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.GetByIdAsync(groupModel.Id, cancellationToken));
        }

        [Fact]
        public void GroupServer_Update_ReturnException()
        {
            //Arrange

            var groups = A.Fake<Group>();
            var groupModel = A.Fake<GroupModel>();
            groups.Id = 0;

            A.CallTo(() => _mapper.Map<Group>(groupModel)).Returns(groups);
            var service = new GroupService(_groupRepository, _cgRepository, _mapper);

            //Act

            //Assert

            Assert.ThrowsAsync<NotFoundException>(() => service.UpdateAsync(groupModel, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => service.UpdateAsync(null, cancellationToken));
        }

        [Fact]
        public void GroupServer_Update_ReturnOk()
        {
            //Arrange

            var groups = A.Fake<Group>();
            var groupModel = A.Fake<GroupModel>();

            A.CallTo(() => _mapper.Map<Group>(groupModel)).Returns(groups);
            var service = new GroupService(_groupRepository, _cgRepository, _mapper);

            //Act
            var result = service.UpdateAsync(groupModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }



        [Fact]
        public void GroupServer_Delete_ReturnOK()
        {
            //Arrange

            var groups = A.Fake<Group>();
            var groupModel = A.Fake<GroupModel>();

            A.CallTo(() => _mapper.Map<Group>(groupModel)).Returns(groups);
            var service = new GroupService(_groupRepository, _cgRepository, _mapper);

            //Act
            var result = service.DeleteAsync(groupModel, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void GroupServer_Delete_ReturnException()
        {
            //Arrange

            var groups = A.Fake<Group>();
            groups.Id = 0;
            var groupModel = A.Fake<GroupModel>();

            A.CallTo(() => _mapper.Map<Group>(groupModel)).Returns(groups);
            var service = new GroupService(_groupRepository, _cgRepository, _mapper);

            //Act

            //Assert
            Assert.ThrowsAsync<NotFoundException>(() => service.DeleteAsync(groupModel, cancellationToken));
            Assert.ThrowsAsync<NotFoundException>(() => service.DeleteAsync(null, cancellationToken));
        }

    }
}
