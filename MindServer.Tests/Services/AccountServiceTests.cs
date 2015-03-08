using System;
using System.Linq.Expressions;
using MindServer.Domain.DataContracts;
using MindServer.Domain.Entities;
using MindServer.Domain.Exceptions;
using MindServer.Services;
using MindServer.Services.Interfaces;
using MindServer.Services.Repository.Interfaces;
using Moq;
using NUnit.Framework;

namespace MindServer.Tests.Services
{
    [TestFixture]
    public class AccountServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUserService = new Mock<IUserService>();
            _accountService = new AccountService(_mockUserService.Object, _mockUnitOfWork.Object);
        }

        private IAccountService _accountService;
        private Mock<IUserService> _mockUserService;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [Test]
        public void AdminLogin_PasswordDoesNotMatchPasswordOnRecord_ResponseContainsErrorMessage()
        {
            _mockUserService.Setup(x => x.GetAdminUser(It.IsAny<AdminLogInRequest>())).Returns(new User
            {
                PasswordSalt = "5AC00FE09CF233D7577E410A8EF754930AD97D44B71DF02E970815DBB4747DE7",
                PasswordHash = "71B58E6C23CB9247A0E9B96CCFF88E249B7AEDA9A4197E7BEA0E906F7A4986CC",
                SessionToken = "AF159851A2D82859A4EA783DC52C02CE5268AFA9E0A4AA1D068DE142DFAC7546"
            });

            var accountSignUpRequest = new AdminLogInRequest
            {
                EmailAddress = "knownUser@test.com",
                Password = "123123",
            };

            var result = _accountService.AdminLogin(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNotNullOrEmpty(resultContent.Message);
        }

        [Test]
        public void AdminLogin_PasswordDoesNotMatchPasswordOnRecord_ResponseSuccessIsFalse()
        {
            _mockUserService.Setup(x => x.GetAdminUser(It.IsAny<AdminLogInRequest>())).Returns(new User
            {
                PasswordSalt = "5AC00FE09CF233D7577E410A8EF754930AD97D44B71DF02E970815DBB4747DE7",
                PasswordHash = "71B58E6C23CB9247A0E9B96CCFF88E249B7AEDA9A4197E7BEA0E906F7A4986CC",
                SessionToken = "AF159851A2D82859A4EA783DC52C02CE5268AFA9E0A4AA1D068DE142DFAC7546"
            });

            var accountSignUpRequest = new AdminLogInRequest
            {
                EmailAddress = "knownUser@test.com",
                Password = "123123",
            };

            var result = _accountService.AdminLogin(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsFalse(resultContent.Success);
        }

        [Test]
        public void AdminLogin_PasswordMatchesPasswordOnRecord_ResponseSuccessIsTrue()
        {
            _mockUserService.Setup(x => x.GetAdminUser(It.IsAny<AdminLogInRequest>())).Returns(new User
            {
                PasswordSalt = "5AC00FE09CF233D7577E410A8EF754930AD97D44B71DF02E970815DBB4747DE7",
                PasswordHash = "71B58E6C23CB9247A0E9B96CCFF88E249B7AEDA9A4197E7BEA0E906F7A4986CC",
                SessionToken = "AF159851A2D82859A4EA783DC52C02CE5268AFA9E0A4AA1D068DE142DFAC7546"
            });

            var accountSignUpRequest = new AdminLogInRequest
            {
                EmailAddress = "knownUser@test.com",
                Password = "123456",
            };

            var result = _accountService.AdminLogin(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsTrue(resultContent.Success);
        }   

        [Test]
        public void AdminLogin_UserDoesntExist_ResposneContainsMessage()
        {
            _mockUserService.Setup(x => x.GetAdminUser(It.IsAny<AdminLogInRequest>()))
                .Throws(new UserDoesNotExistException());

            var accountSignUpRequest = new AdminLogInRequest
            {
                EmailAddress = "unknownUser@test.com",
                Password = "123123",
            };

            var result = _accountService.AdminLogin(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNotNullOrEmpty(resultContent.Message);
        }

        [Test]
        public void AdminLogin_UserDoesntExist_ResposneReturnedWithSuccessAsFalse()
        {
            _mockUserService.Setup(x => x.GetAdminUser(It.IsAny<AdminLogInRequest>()))
                .Throws(new UserDoesNotExistException());

            var accountSignUpRequest = new AdminLogInRequest
            {
                EmailAddress = "unknownUser@test.com",
                Password = "123123",
            };

            var result = _accountService.AdminLogin(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsFalse(resultContent.Success);
        }

        [Test]
        public void AuthenticateSessionToken_InValidSessionToken_InvalidSessionTokenExceptionNotThrown()
        {
            _mockUnitOfWork.Setup(x => x.UserRepository.Single(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(default(User));

            Assert.Throws<InvalidSessionTokenException>(() => _accountService.AuthenticateSessionToken("1231231323"));
        }

        [Test]
        public void AuthenticateSessionToken_ValidSessionToken_InvalidSessionTokenExceptionNotThrown()
        {
            _mockUnitOfWork.Setup(x => x.UserRepository.Single(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new User());

            Assert.DoesNotThrow(() => _accountService.AuthenticateSessionToken(""));
        }

        [Test]
        public void UserLogIn_PasswordDoesNotMatchPasswordOnRecord_ResponseContainsErrorMessage()
        {
            _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
            {
                PasswordSalt = "5AC00FE09CF233D7577E410A8EF754930AD97D44B71DF02E970815DBB4747DE7",
                PasswordHash = "71B58E6C23CB9247A0E9B96CCFF88E249B7AEDA9A4197E7BEA0E906F7A4986CC",
                SessionToken = "AF159851A2D82859A4EA783DC52C02CE5268AFA9E0A4AA1D068DE142DFAC7546"
            });

            var accountSignUpRequest = new AccountLogInRequest
            {
                EmailAddress = "knownUser@test.com",
                Password = "123123",
            };

            var result = _accountService.UserLogIn(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNotNullOrEmpty(resultContent.Message);
        }

        [Test]
        public void UserLogIn_PasswordDoesNotMatchPasswordOnRecord_ResponseSessionTokenIsEmpty()
        {
            _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
            {
                PasswordSalt = "5AC00FE09CF233D7577E410A8EF754930AD97D44B71DF02E970815DBB4747DE7",
                PasswordHash = "71B58E6C23CB9247A0E9B96CCFF88E249B7AEDA9A4197E7BEA0E906F7A4986CC",
                SessionToken = "AF159851A2D82859A4EA783DC52C02CE5268AFA9E0A4AA1D068DE142DFAC7546"
            });

            var accountSignUpRequest = new AccountLogInRequest
            {
                EmailAddress = "knownUser@test.com",
                Password = "123123",
            };

            var result = _accountService.UserLogIn(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNullOrEmpty(resultContent.SessionToken);
        }

        [Test]
        public void UserLogIn_PasswordDoesNotMatchPasswordOnRecord_ResponseSuccessIsFalse()
        {
            _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
            {
                PasswordSalt = "5AC00FE09CF233D7577E410A8EF754930AD97D44B71DF02E970815DBB4747DE7",
                PasswordHash = "71B58E6C23CB9247A0E9B96CCFF88E249B7AEDA9A4197E7BEA0E906F7A4986CC",
                SessionToken = "AF159851A2D82859A4EA783DC52C02CE5268AFA9E0A4AA1D068DE142DFAC7546"
            });

            var accountSignUpRequest = new AccountLogInRequest
            {
                EmailAddress = "knownUser@test.com",
                Password = "123123",
            };

            var result = _accountService.UserLogIn(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsFalse(resultContent.Success);
        }

        [Test]
        public void UserLogIn_PasswordMatchesPasswordOnRecord_ResponseContainsANewSessionToken()
        {
            const string sessionToken = "AF159851A2D82859A4EA783DC52C02CE5268AFA9E0A4AA1D068DE142DFAC7546";

            _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
            {
                PasswordSalt = "5AC00FE09CF233D7577E410A8EF754930AD97D44B71DF02E970815DBB4747DE7",
                PasswordHash = "71B58E6C23CB9247A0E9B96CCFF88E249B7AEDA9A4197E7BEA0E906F7A4986CC",
                SessionToken = sessionToken
            });

            var accountSignUpRequest = new AccountLogInRequest
            {
                EmailAddress = "knownUser@test.com",
                Password = "123456",
            };

            var result = _accountService.UserLogIn(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNotNullOrEmpty(resultContent.SessionToken);
            Assert.AreNotEqual(sessionToken, resultContent.SessionToken);
        }

        [Test]
        public void UserLogIn_PasswordMatchesPasswordOnRecord_ResponseSuccessIsTrue()
        {
            _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
            {
                PasswordSalt = "5AC00FE09CF233D7577E410A8EF754930AD97D44B71DF02E970815DBB4747DE7",
                PasswordHash = "71B58E6C23CB9247A0E9B96CCFF88E249B7AEDA9A4197E7BEA0E906F7A4986CC",
                SessionToken = "AF159851A2D82859A4EA783DC52C02CE5268AFA9E0A4AA1D068DE142DFAC7546"
            });

            var accountSignUpRequest = new AccountLogInRequest
            {
                EmailAddress = "knownUser@test.com",
                Password = "123456",
            };

            var result = _accountService.UserLogIn(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsTrue(resultContent.Success);
        }

        [Test]
        public void UserLogIn_PasswordMatchesPasswordOnRecord_UserDetailsAreUpdated()
        {
            _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
            {
                PasswordSalt = "5AC00FE09CF233D7577E410A8EF754930AD97D44B71DF02E970815DBB4747DE7",
                PasswordHash = "71B58E6C23CB9247A0E9B96CCFF88E249B7AEDA9A4197E7BEA0E906F7A4986CC",
                SessionToken = "AF159851A2D82859A4EA783DC52C02CE5268AFA9E0A4AA1D068DE142DFAC7546"
            });

            var accountSignUpRequest = new AccountLogInRequest
            {
                EmailAddress = "knownUser@test.com",
                Password = "123456",
            };

            _accountService.UserLogIn(accountSignUpRequest);

            _mockUnitOfWork.Verify(x => x.SaveChangesAsync());
        }

        [Test]
        public void UserLogIn_UserDoesntExist_ResposneContainsMessage()
        {
            _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>()))
                .Throws(new UserDoesNotExistException());

            var accountSignUpRequest = new AccountLogInRequest
            {
                EmailAddress = "unknownUser@test.com",
                Password = "123123",
            };

            var result = _accountService.UserLogIn(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNotNullOrEmpty(resultContent.Message);
        }

        [Test]
        public void UserLogIn_UserDoesntExist_ResposneDoesNotContainSessionToken()
        {
            _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>()))
                .Throws(new UserDoesNotExistException());

            var accountSignUpRequest = new AccountLogInRequest
            {
                EmailAddress = "unknownUser@test.com",
                Password = "123123",
            };

            var result = _accountService.UserLogIn(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNullOrEmpty(resultContent.SessionToken);
        }

        [Test]
        public void UserLogIn_UserDoesntExist_ResposneReturnedWithSuccessAsFalse()
        {
            _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>()))
                .Throws(new UserDoesNotExistException());

            var accountSignUpRequest = new AccountLogInRequest
            {
                EmailAddress = "unknownUser@test.com",
                Password = "123123",
            };

            var result = _accountService.UserLogIn(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsFalse(resultContent.Success);
        }

        [Test]
        public void UserLogOut_UserDoesntExist_ResposneContainsMessage()
        {
            _mockUserService.Setup(x => x.CheckUserExists(It.IsAny<string>()))
                .Throws(new UserDoesNotExistException());

            var accountSignUpRequest = new AccountLogOutRequest
            {
                EmailAddress = "unknownUser@test.com",
            };

            var result = _accountService.UserLogOut(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNotNullOrEmpty(resultContent.Message);
        }

        [Test]
        public void UserLogOut_UserDoesntExist_ResposneSuccessIsFalse()
        {
            _mockUserService.Setup(x => x.CheckUserExists(It.IsAny<string>()))
                .Throws(new UserDoesNotExistException());

            var accountSignUpRequest = new AccountLogOutRequest
            {
                EmailAddress = "unknownUser@test.com",
            };

            var result = _accountService.UserLogOut(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsFalse(resultContent.Success);
        }

        [Test]
        public void UserLogOut_ValidUser_DbSaveIsCalled()
        {
            _mockUserService.Setup(x => x.CheckUserExists(It.IsAny<string>()));

            _mockUnitOfWork.Setup(x => x.UserRepository.Single(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new User());

            var accountSignUpRequest = new AccountLogOutRequest
            {
                EmailAddress = "unknownUser@test.com",
            };

            _accountService.UserLogOut(accountSignUpRequest);


            _mockUnitOfWork.Verify(x => x.SaveChangesAsync());
        }

        [Test]
        public void UserLogOut_ValidUser_ResposneSuccessIsTrue()
        {
            _mockUserService.Setup(x => x.CheckUserExists(It.IsAny<string>()));
            _mockUnitOfWork.Setup(x => x.UserRepository.Single(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(new User());

            var accountSignUpRequest = new AccountLogOutRequest
            {
                EmailAddress = "unknownUser@test.com",
            };

            var result = _accountService.UserLogOut(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsTrue(resultContent.Success);
        }

        [Test]
        public void UserSignUp_SignUpSuccesful_ResponseReturnedContainsSessionToken()
        {
            _mockUserService.Setup(x => x.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()));
            _mockUnitOfWork.Setup(x => x.UserRepository.Create(It.IsAny<User>())).Verifiable();

            var accountSignUpRequest = new AccountSignUpRequest
            {
                Username = "user@test.com",
                Password = "123123",
                DateOfBirth = DateTime.Now
            };

            var result = _accountService.UserSignUp(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNotNullOrEmpty(resultContent.SessionToken);
        }

        [Test]
        public void UserSignUp_SignUpSuccesful_ResponseReturnedSuccessFlagIsTrue()
        {
            _mockUserService.Setup(x => x.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()));
            _mockUnitOfWork.Setup(x => x.UserRepository.Create(It.IsAny<User>())).Verifiable();

            var accountSignUpRequest = new AccountSignUpRequest
            {
                Username = "user@test.com",
                Password = "123123",
                DateOfBirth = DateTime.Now
            };

            var result = _accountService.UserSignUp(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsTrue(resultContent.Success);
        }

        [Test]
        public void UserSignUp_UserAlreadyExists_ResponseContainsFalseSuccessFlag()
        {
            _mockUserService.Setup(x => x.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()))
                .Throws(new UserAlreadyExistsException());

            var accountSignUpRequest = new AccountSignUpRequest
            {
                Username = "existingUser@test.com",
                Password = "123123",
                DateOfBirth = DateTime.Now
            };

            var result = _accountService.UserSignUp(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsFalse(resultContent.Success);
        }

        [Test]
        public void UserSignUp_UserAlreadyExists_ResponseMessageIsNotEmpty()
        {
            _mockUserService.Setup(x => x.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()))
                .Throws(new UserAlreadyExistsException());

            var accountSignUpRequest = new AccountSignUpRequest
            {
                Username = "existingUser@test.com",
                Password = "123123",
                DateOfBirth = DateTime.Now
            };

            var result = _accountService.UserSignUp(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNotNullOrEmpty(resultContent.Message);
        }

        [Test]
        public void UserSignUp_UserAlreadyExists_ResponseSessionTokenIsEmpty()
        {
            _mockUserService.Setup(x => x.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()))
                .Throws(new UserAlreadyExistsException());

            var accountSignUpRequest = new AccountSignUpRequest
            {
                Username = "existingUser@test.com",
                Password = "123123",
                DateOfBirth = DateTime.Now
            };

            var result = _accountService.UserSignUp(accountSignUpRequest);
            var resultContent = result.Result;

            Assert.IsNullOrEmpty(resultContent.SessionToken);
        }
    }
}