using System;
using System.Linq.Expressions;
using MindServer.Domain.Entities;
using MindServer.Domain.Exceptions;
using MindServer.Services;
using MindServer.Services.DataContracts;
using MindServer.Services.Interfaces;
using MindServer.Services.Repository.Interfaces;
using Moq;
using NUnit.Framework;

namespace MindServer.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _userService = new UserService(_unitOfWork.Object);
        }

        private IUserService _userService;
        private Mock<IUnitOfWork> _unitOfWork;

        [Test]
        public void CheckUserExists_UserExists_UserDoesNotExistExceptionNotThrown()
        {
            _unitOfWork.Setup(x => x.UserRepository.Exists(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);
            Assert.DoesNotThrow(() => _userService.CheckUserExists("knownUser@test.com"));
        }

        [Test]
        public void CheckUserExists_UserDoesNotExist_UserDoesNotExistExceptionThrown()
        {
            _unitOfWork.Setup(x => x.UserRepository.Exists(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);
            Assert.Throws<UserDoesNotExistException>(() => _userService.CheckUserExists("unknownUser@test.com"));
        }

        [Test]
        public void CheckUserDoesntExist_UserExists_UserAlreadyExistsExceptionThrown()
        {
            _unitOfWork.Setup(x => x.UserRepository.Exists(It.IsAny<Expression<Func<User, bool>>>())).Returns(true);
            Assert.Throws<UserAlreadyExistsException>(() => _userService.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()));
        }

        [Test]
        public void CheckUserDoesntExist_UserDoesntExist_UserAlreadyExistsExceptionNotThrown()
        {
            _unitOfWork.Setup(x => x.UserRepository.Exists(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);
            Assert.DoesNotThrow(() => _userService.CheckUserDoesntExist(new AccountSignUpRequest()
            {
                Username = "unknownUser@test.com"
            }));
        }

        [Test]
        public void GetUser_UserExists_UserReturned()
        {
            _unitOfWork.Setup(x => x.UserRepository.Exists(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(true);
            _unitOfWork.Setup(x => x.UserRepository.Single(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new User());

            var returnedUser = _userService.GetUser(new AccountLogInRequest()
            {
                EmailAddress = "knownUser@test.com"
            });

            Assert.IsInstanceOf<User>(returnedUser);
        }

        [Test]
        public void GetUser_UserExists_UserDoesNotExistExceptionNotThrown()
        {
            _unitOfWork.Setup(x => x.UserRepository.Single(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns((User) null);

            Assert.Throws<UserDoesNotExistException>(() => _userService.GetUser(new AccountLogInRequest()
            {
                EmailAddress = "unknownUser@test.com"
            }));
        }

        [Test]
        public void GetUser_UserDoesNotExist_UserDoesNotExistExceptionThrown()
        {
            _unitOfWork.Setup(x => x.UserRepository.Exists(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(false);

            Assert.Throws<UserDoesNotExistException>(() => _userService.GetUser(new AccountLogInRequest()
            {
                EmailAddress = "unknownUser@test.com"
            }));
        }
    }
}