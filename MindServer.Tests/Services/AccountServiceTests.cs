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
        // [SetUp]
        // public void SetUp()
        // {
        //     _mockUnitOfWork = new Mock<IUnitOfWork>();
        //     _mockUserService = new Mock<IUserService>();
        //     _accountService = new AccountService(_mockUserService.Object, _mockUnitOfWork.Object);
        // }

        // private IAccountService _accountService;
        // private Mock<IUserService> _mockUserService;
        // private Mock<IUnitOfWork> _mockUnitOfWork;

        // [Test]
        // public void UserLogIn_PasswordDoesNotMatchPasswordOnRecord_ResponseContainsErrorMessage()
        // {
        //     _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
        //     {
        //         PasswordSalt = "",
        //         PasswordHash = "",
        //         SessionToken = ""
        //     });

        //     var accountSignUpRequest = new AccountLogInRequest
        //     {
        //         EmailAddress = "knownUser@test.com",
        //         Password = "123123",
        //     };

        //     var result = _accountService.UserLogIn(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsNotNullOrEmpty(resultContent.Message);
        // }

        // [Test]
        // public void UserLogIn_PasswordDoesNotMatchPasswordOnRecord_ResponseSessionTokenIsEmpty()
        // {
        //     _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
        //     {
        //         PasswordSalt = "",
        //         PasswordHash = "",
        //         SessionToken = ""
        //     });

        //     var accountSignUpRequest = new AccountLogInRequest
        //     {
        //         EmailAddress = "knownUser@test.com",
        //         Password = "123123",
        //     };

        //     var result = _accountService.UserLogIn(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsNullOrEmpty(resultContent.SessionToken);
        // }

        // [Test]
        // public void UserLogIn_PasswordDoesNotMatchPasswordOnRecord_ResponseSuccessIsFalse()
        // {
        //     _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
        //     {
        //         PasswordSalt = "",
        //         PasswordHash = "",
        //         SessionToken = ""
        //     });

        //     var accountSignUpRequest = new AccountLogInRequest
        //     {
        //         EmailAddress = "knownUser@test.com",
        //         Password = "123123",
        //     };

        //     var result = _accountService.UserLogIn(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsFalse(resultContent.Success);
        // }

        // [Test]
        // public void UserLogIn_PasswordDoesNotMatchPasswordOnRecord_UserAuthenticationErrorThrown()
        // {
        //     _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
        //     {
        //         PasswordSalt = "",
        //         PasswordHash = "",
        //         SessionToken = ""
        //     });

        //     var accountSignUpRequest = new AccountLogInRequest
        //     {
        //         EmailAddress = "knownUser@test.com",
        //         Password = "123123",
        //     };

        //     Assert.Throws<UserAuthenticationException>(() => _accountService.UserLogIn(accountSignUpRequest));
        // }

        // [Test]
        // public void UserLogIn_PasswordMatchesPasswordOnRecord_ResponseContainsCorrectSessionToken()
        // {
        //     var sessionToken = "";

        //     _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
        //     {
        //         PasswordSalt = "",
        //         PasswordHash = "",
        //         SessionToken = sessionToken
        //     });

        //     var accountSignUpRequest = new AccountLogInRequest
        //     {
        //         EmailAddress = "knownUser@test.com",
        //         Password = "123123",
        //     };

        //     var result = _accountService.UserLogIn(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsNotNullOrEmpty(resultContent.SessionToken);
        //     Assert.AreEqual(sessionToken, resultContent.SessionToken);
        // }

        // [Test]
        // public void UserLogIn_PasswordMatchesPasswordOnRecord_ResponseSuccessIsTrue()
        // {
        //     _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
        //     {
        //         PasswordSalt = "",
        //         PasswordHash = "",
        //         SessionToken = ""
        //     });

        //     var accountSignUpRequest = new AccountLogInRequest
        //     {
        //         EmailAddress = "knownUser@test.com",
        //         Password = "123123",
        //     };

        //     var result = _accountService.UserLogIn(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsTrue(resultContent.Success);
        // }

        // [Test]
        // public void UserLogIn_PasswordMatchesPasswordOnRecord_UserDetailsAreUpdated()
        // {
        //     _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>())).Returns(new User
        //     {
        //         PasswordSalt = "",
        //         PasswordHash = "",
        //         SessionToken = ""
        //     });

        //     var accountSignUpRequest = new AccountLogInRequest
        //     {
        //         EmailAddress = "knownUser@test.com",
        //         Password = "123123",
        //     };

        //     _accountService.UserLogIn(accountSignUpRequest);

        //     _mockUnitOfWork.Verify(x => x.SaveChangesAsync());
        // }

        // [Test]
        // public void UserLogIn_UserDoesntExist_ResposneContainsMessage()
        // {
        //     _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>()))
        //         .Throws(new UserDoesNotExistException());

        //     var accountSignUpRequest = new AccountLogInRequest
        //     {
        //         EmailAddress = "unknownUser@test.com",
        //         Password = "123123",
        //     };

        //     var result = _accountService.UserLogIn(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsNotNullOrEmpty(resultContent.Message);
        // }

        // [Test]
        // public void UserLogIn_UserDoesntExist_ResposneDoesNotContainSessionToken()
        // {
        //     _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>()))
        //         .Throws(new UserDoesNotExistException());

        //     var accountSignUpRequest = new AccountLogInRequest
        //     {
        //         EmailAddress = "unknownUser@test.com",
        //         Password = "123123",
        //     };

        //     var result = _accountService.UserLogIn(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsNullOrEmpty(resultContent.SessionToken);
        // }

        // [Test]
        // public void UserLogIn_UserDoesntExist_ResposneReturnedWithSuccessAsFalse()
        // {
        //     _mockUserService.Setup(x => x.GetUser(It.IsAny<AccountLogInRequest>()))
        //         .Throws(new UserDoesNotExistException());

        //     var accountSignUpRequest = new AccountLogInRequest
        //     {
        //         EmailAddress = "unknownUser@test.com",
        //         Password = "123123",
        //     };

        //     var result = _accountService.UserLogIn(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsFalse(resultContent.Success);
        // }

        // [Test]
        // public void UserSignUp_SignUpSuccesful_ResponseReturnedContainsSessionToken()
        // {
        //     _mockUserService.Setup(x => x.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()));

        //     var accountSignUpRequest = new AccountSignUpRequest
        //     {
        //         Username = "user@test.com",
        //         Password = "123123",
        //         DateOfBirth = DateTime.Now
        //     };

        //     var result = _accountService.UserSignUp(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsNotNullOrEmpty(resultContent.SessionToken);
        // }

        // [Test]
        // public void UserSignUp_SignUpSuccesful_ResponseReturnedSuccessFlagIsTrue()
        // {
        //     _mockUserService.Setup(x => x.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()));

        //     var accountSignUpRequest = new AccountSignUpRequest
        //     {
        //         Username = "user@test.com",
        //         Password = "123123",
        //         DateOfBirth = DateTime.Now
        //     };

        //     var result = _accountService.UserSignUp(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsTrue(resultContent.Success);
        // }

        // [Test]
        // public void UserSignUp_UserAlreadyExists_ResponseContainsFalseSuccessFlag()
        // {
        //     _mockUserService.Setup(x => x.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()))
        //         .Throws(new UserAlreadyExistsException());

        //     var accountSignUpRequest = new AccountSignUpRequest
        //     {
        //         Username = "existingUser@test.com",
        //         Password = "123123",
        //         DateOfBirth = DateTime.Now
        //     };

        //     var result = _accountService.UserSignUp(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsFalse(resultContent.Success);
        // }

        // [Test]
        // public void UserSignUp_UserAlreadyExists_ResponseMessageIsNotEmpty()
        // {
        //     _mockUserService.Setup(x => x.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()))
        //         .Throws(new UserAlreadyExistsException());

        //     var accountSignUpRequest = new AccountSignUpRequest
        //     {
        //         Username = "existingUser@test.com",
        //         Password = "123123",
        //         DateOfBirth = DateTime.Now
        //     };

        //     var result = _accountService.UserSignUp(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsNotNullOrEmpty(resultContent.Message);
        // }

        // [Test]
        // public void UserSignUp_UserAlreadyExists_ResponseSessionTokenIsEmpty()
        // {
        //     _mockUserService.Setup(x => x.CheckUserDoesntExist(It.IsAny<AccountSignUpRequest>()))
        //         .Throws(new UserAlreadyExistsException());

        //     var accountSignUpRequest = new AccountSignUpRequest
        //     {
        //         Username = "existingUser@test.com",
        //         Password = "123123",
        //         DateOfBirth = DateTime.Now
        //     };

        //     var result = _accountService.UserSignUp(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsNullOrEmpty(resultContent.SessionToken);
        // }

        // [Test]
        // public void UserLogOut_UserDoesntExist_ResposneSuccessIsFalse()
        // {
        //     _mockUserService.Setup(x => x.CheckUserExists(It.IsAny<string>()))
        //         .Throws(new UserDoesNotExistException());

        //     var accountSignUpRequest = new AccountLogOutRequest()
        //     {
        //         EmailAddress = "unknownUser@test.com",
        //     };

        //     var result = _accountService.UserLogOut(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsFalse(resultContent.Success);
        // }

        // [Test]
        // public void UserLogOut_UserDoesntExist_ResposneContainsMessage()
        // {
        //     _mockUserService.Setup(x => x.CheckUserExists(It.IsAny<string>()))
        //         .Throws(new UserDoesNotExistException());

        //     var accountSignUpRequest = new AccountLogOutRequest
        //     {
        //         EmailAddress = "unknownUser@test.com",
        //     };

        //     var result = _accountService.UserLogOut(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsNotNullOrEmpty(resultContent.Message);
        // }

        // [Test]
        // public void UserLogOut_ValidUser_DbSaveIsCalled()
        // {
        //     _mockUserService.Setup(x => x.CheckUserExists(It.IsAny<string>()));

        //     var accountSignUpRequest = new AccountLogOutRequest
        //     {
        //         EmailAddress = "unknownUser@test.com",
        //     };

        //     _accountService.UserLogOut(accountSignUpRequest);
            

        //     _mockUnitOfWork.Verify(x =>x.SaveChangesAsync());
        // }

        // [Test]
        // public void UserLogOut_ValidUser_ResposneSuccessIsTrue()
        // {
        //     _mockUserService.Setup(x => x.CheckUserExists(It.IsAny<string>()));

        //     var accountSignUpRequest = new AccountLogOutRequest
        //     {
        //         EmailAddress = "unknownUser@test.com",
        //     };

        //     var result = _accountService.UserLogOut(accountSignUpRequest);
        //     var resultContent = result.Result;

        //     Assert.IsTrue(resultContent.Success);
        // }

        // [Test]
        // public void AuthenticateSessionToken_ValidSessionToken_InvalidSessionTokenExceptionNotThrown()
        // {
        //     _mockUnitOfWork.Setup(x => x.UserRepository.Single(It.IsAny<Expression<Func<User, bool>>>()))
        //         .Returns(new User());

        //     Assert.DoesNotThrow(() => _accountService.AuthenticateSessionToken(""));
        // }

        // [Test]
        // public void AuthenticateSessionToken_InValidSessionToken_InvalidSessionTokenExceptionNotThrown()
        // {
        //     Assert.Throws<InvalidSessionTokenException>(() => _accountService.AuthenticateSessionToken(""));
        // }

        // //[SetUp]
        // //public void SetUp()
        // //{
        // //    _mindServerDbContext = MockRepository.GenerateStub<MindServerDbContext>();
        // //    _mindServerDbContext.Users = new FakeDbSet<User>();

        // //    //_unitOfWork = MockRepository.GenerateStub<IUnitOfWork>();
        // //    //_unitOfWork.Stub(x => x.UserRepository).Return(_userRepository);

        // //    _userRepository = MockRepository.GenerateStub<IUserRepository>();

        // //    _unitOfWork = new EFUnitOfWork(_mindServerDbContext);
        // //    _accountService = new AccountService(_unitOfWork);
        // //}

        // //private IUnitOfWork _unitOfWork;
        // //private MindServerDbContext _mindServerDbContext;
        // //private IAccountService _accountService;
        // //private IUserRepository _userRepository;

        // //[Test]
        // //public void UserSignUp_UserAlreadyExists_ReturnsResponseObjectContainsEmptySessionToken()
        // //{
        // //    var request = new AccountSignUpRequest
        // //    {
        // //        Username = "existingUser@test.com",
        // //        Password = "123456"
        // //    };

        // //    var responseTask = _accountService.AccountSignUp(request);
        // //    var response = responseTask.Result;

        // //    Assert.IsNullOrEmpty(response.SessionToken);
        // //}

        // //[Test]
        // //public void UserSignUp_UserAlreadyExists_ReturnsResponseObjectContainsErrorMessage()
        // //{
        // //    var request = new AccountSignUpRequest
        // //    {
        // //        Username = "existingUser@test.com",
        // //        Password = "123456"
        // //    };

        // //    var responseTask = _accountService.AccountSignUp(request);
        // //    var response = responseTask.Result;

        // //    Assert.IsNotNullOrEmpty(response.ResponseContract);
        // //}

        // //[Test]
        // //public void UserSignUp_UserAlreadyExists_ReturnsResponseObjectWithSuccessFalse()
        // //{
        // //    _mindServerDbContext.Users.Add(new User
        // //    {
        // //        EmailAddress = "existingUser@test.com"
        // //    });

        // //    //_unitOfWork.UserRepository.Stub(x => x.Exists(It.IsAny<Expression<Func<User, bool>>>()))
        // //    //    .Return(true);

        // //    var request = new AccountSignUpRequest
        // //    {
        // //        Username = "existingUser@test.com",
        // //        Password = "123456"
        // //    };

        // //    var responseTask = _accountService.AccountSignUp(request);
        // //    var response = responseTask.Result;

        // //    Assert.IsFalse(response.Success);
        // //}
    }
}