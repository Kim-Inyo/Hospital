using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Logic;
using Domain.Models;
using Domain.UseCase;
using Moq;


namespace UnitTests
{
    public class UserTest
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public void IsExistsTest()
        {
            _userRepositoryMock.Setup(repository => repository.IsExists(It.IsAny<int>())).Returns(() => false);

            var res = _userService.IsExists(0);

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Id", res.Error);
        }

        [Fact]
        public void AddUserTest()
        {
            _userRepositoryMock.Setup(repository => repository.AddUser(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Role>())).Returns(() => null);

            var res = _userService.AddUser("qwes", "213465", new Role());

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid User", res.Error);
            Assert.Equal("User Exists", res.Error);
            Assert.Equal("Failed to add user", res.Error);
        }

        [Fact]
        public void GetUserByLoginTest()
        {
            _userRepositoryMock.Setup(repository => repository.GetUserByLogin(It.IsAny<int>())).Returns(() => null);

            var res = _userService.GetUserByLogin(0);

            Assert.True(res.IsFailure);
            Assert.Equal("Invalid Id", res.Error);
            Assert.Equal("User Not Found", res.Error);
        }
    }
}
