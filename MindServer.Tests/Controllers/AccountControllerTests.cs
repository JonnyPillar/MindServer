using System;
using System.Threading.Tasks;
using System.Web.Http.Results;
using MindServer.Controllers;
using MindServer.Domain.ActionResults;
using MindServer.Domain.DataContracts;
using MindServer.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace MindServer.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        // [SetUp]
        // public void SetUp()
        // {
        //     _mockAccountService = new Mock<IAccountService>();
        //     _accountController = new AccountController(_mockAccountService.Object);
        // }

        // private Mock<IAccountService> _mockAccountService;
        // private AccountController _accountController;

        // [Test]
        // public void LogIn_AccountServiceReturnesUnSuccessFullResponse_BadRequestResonseReturned()
        // {
        //     _mockAccountService.Setup(x => x.UserLogIn(It.IsAny<AccountLogInRequest>()))
        //         .Returns(new Task<AccountLogInResponse>(() => new AccountLogInResponse
        //         {
        //             Success = false
        //         }));

        //     var accountSignUp = new AccountLogInRequest
        //     {
        //         EmailAddress = "testUser@test.com",
        //         Password = "123123",
        //     };

        //     var response = _accountController.LogIn(accountSignUp);
        //     var responseContent = response.Result;

        //     Assert.IsInstanceOf<BadRequestResponse>(responseContent);
        // }

        // [Test]
        // public void LogIn_AccountServiceThrowsException_ExceptionResponseResonseReturned()
        // {
        //     _mockAccountService.Setup(x => x.UserLogIn(It.IsAny<AccountLogInRequest>()))
        //         .Throws(new Exception());

        //     var accountSignUp = new AccountLogInRequest
        //     {
        //         EmailAddress = "testUser@test.com",
        //         Password = "123123",
        //     };

        //     var response = _accountController.LogIn(accountSignUp);
        //     var responseContent = response.Result;

        //     Assert.IsInstanceOf<ExceptionResult>(responseContent);
        // }

        // [Test]
        // [TestCase(null)]
        // [TestCase("")]
        // public void LogIn_InvalidModelInvalidEmailAddress_BadRequestResponseReturned(string emailAddress)
        // {
        //     var accountSignUp = new AccountLogInRequest
        //     {
        //         EmailAddress = emailAddress,
        //         Password = "123123",
        //     };

        //     var response = _accountController.LogIn(accountSignUp);
        //     var resultContent = response.Result;

        //     Assert.IsInstanceOf<BadRequestResponse>(resultContent);
        // }

        // [Test]
        // [TestCase(null)]
        // [TestCase("")]
        // public void LogIn_InvalidModelInvalidPassword_BadRequestResponseReturned(string password)
        // {
        //     var accountSignUp = new AccountLogInRequest
        //     {
        //         EmailAddress = "testUser@test.com",
        //         Password = password,
        //     };

        //     var response = _accountController.LogIn(accountSignUp);
        //     var resultContent = response.Result;

        //     Assert.IsInstanceOf<BadRequestResponse>(resultContent);
        // }

        // [Test]
        // public void LogOut_AccountServiceReturnesSuccessResponse_OkResonseReturned()
        // {
        //     _mockAccountService.Setup(x => x.UserLogOut(It.IsAny<AccountLogOutRequest>()))
        //         .Returns(new Task<AccountLogOutResponse>(() => new AccountLogOutResponse
        //         {
        //             Success = true
        //         }));

        //     var accountSignUp = new AccountLogOutRequest
        //     {
        //         EmailAddress = "testUser@test.com",
        //     };

        //     var response = _accountController.LogOut(accountSignUp);
        //     var responseContent = response.Result;

        //     var result = responseContent as OkNegotiatedContentResult<AccountSignUpResponse>;
        // }

        // [Test]
        // public void LogOut_AccountServiceReturnesUnSuccessFullResponse_BadRequestResonseReturned()
        // {
        //     _mockAccountService.Setup(x => x.UserLogOut(It.IsAny<AccountLogOutRequest>()))
        //         .Returns(new Task<AccountLogOutResponse>(() => new AccountLogOutResponse
        //         {
        //             Success = false
        //         }));

        //     var accountSignUp = new AccountLogOutRequest
        //     {
        //         EmailAddress = "testUser@test.com",
        //     };

        //     var response = _accountController.LogOut(accountSignUp);
        //     var responseContent = response.Result;

        //     Assert.IsInstanceOf<BadRequestResponse>(responseContent);
        // }

        // [Test]
        // public void LogOut_AccountServiceThrowsException_ExceptionResponseResonseReturned()
        // {
        //     _mockAccountService.Setup(x => x.UserLogOut(It.IsAny<AccountLogOutRequest>()))
        //         .Throws(new Exception());

        //     var accountSignUp = new AccountLogOutRequest
        //     {
        //         EmailAddress = "testUser@test.com",
        //     };

        //     var response = _accountController.LogOut(accountSignUp);
        //     var responseContent = response.Result;

        //     Assert.IsInstanceOf<ExceptionResult>(responseContent);
        // }

        // [Test]
        // [TestCase(null)]
        // [TestCase("")]
        // public void LogOut_InvalidModelInvalidEmailAddress_BadRequestResponseReturned(string emailAddress)
        // {
        //     var accountSignUp = new AccountLogOutRequest
        //     {
        //         EmailAddress = emailAddress,
        //     };

        //     var response = _accountController.LogOut(accountSignUp);
        //     var resultContent = response.Result;

        //     Assert.IsInstanceOf<BadRequestResponse>(resultContent);
        // }

        // [Test]
        // public void Login_AccountServiceReturnesSuccessResponse_OkResonseReturned()
        // {
        //     _mockAccountService.Setup(x => x.UserLogIn(It.IsAny<AccountLogInRequest>()))
        //         .Returns(new Task<AccountLogInResponse>(() => new AccountLogInResponse
        //         {
        //             Success = true
        //         }));

        //     var accountSignUp = new AccountLogInRequest
        //     {
        //         EmailAddress = "testUser@test.com",
        //         Password = "123123",
        //     };

        //     var response = _accountController.LogIn(accountSignUp);
        //     var responseContent = response.Result;

        //     var result = responseContent as OkNegotiatedContentResult<AccountSignUpResponse>;
        // }

        // [Test]
        // public void SignUp_AccountServiceReturnesSuccessResponse_OkResonseReturned()
        // {
        //     _mockAccountService.Setup(x => x.UserSignUp(It.IsAny<AccountSignUpRequest>()))
        //         .Returns(new Task<AccountSignUpResponse>(() => new AccountSignUpResponse
        //         {
        //             Success = true
        //         }));

        //     var accountSignUp = new AccountSignUpRequest
        //     {
        //         Username = "testUser@test.com",
        //         Password = "123123",
        //         DateOfBirth = DateTime.Now
        //     };

        //     var response = _accountController.SignUp(accountSignUp);
        //     var responseContent = response.Result;

        //     var result = responseContent as OkNegotiatedContentResult<AccountSignUpResponse>;
        // }


        // [Test]
        // public void SignUp_AccountServiceReturnesUnSuccessFullResponse_BadRequestResonseReturned()
        // {
        //     _mockAccountService.Setup(x => x.UserSignUp(It.IsAny<AccountSignUpRequest>()))
        //         .Returns(new Task<AccountSignUpResponse>(() => new AccountSignUpResponse
        //         {
        //             Success = false
        //         }));

        //     var accountSignUp = new AccountSignUpRequest
        //     {
        //         Username = "testUser@test.com",
        //         Password = "123123",
        //         DateOfBirth = DateTime.Now
        //     };

        //     var response = _accountController.SignUp(accountSignUp);
        //     var responseContent = response.Result;

        //     Assert.IsInstanceOf<BadRequestResponse>(responseContent);
        // }

        // [Test]
        // public void SignUp_AccountServiceThrowsException_ExceptionResponseResonseReturned()
        // {
        //     _mockAccountService.Setup(x => x.UserSignUp(It.IsAny<AccountSignUpRequest>()))
        //         .Throws(new Exception());

        //     var accountSignUp = new AccountSignUpRequest
        //     {
        //         Username = "testUser@test.com",
        //         Password = "123123",
        //         DateOfBirth = DateTime.Now
        //     };

        //     var response = _accountController.SignUp(accountSignUp);
        //     var responseContent = response.Result;

        //     Assert.IsInstanceOf<ExceptionResult>(responseContent);
        // }

        // [Test]
        // [TestCase(null)]
        // [TestCase("")]
        // public void SignUp_InvalidModelInvalidPassword_BadRequestReturned(string password)
        // {
        //     var accountSignUp = new AccountSignUpRequest
        //     {
        //         Username = "username",
        //         Password = password,
        //         DateOfBirth = DateTime.Now
        //     };

        //     var response = _accountController.SignUp(accountSignUp);
        //     var resultContent = response.Result;

        //     Assert.IsInstanceOf<BadRequestResponse>(resultContent);
        // }

        // [Test]
        // [TestCase(null)]
        // [TestCase("")]
        // public void SignUp_InvalidModelInvalidUsername_BadRequestReturned(string username)
        // {
        //     var accountSignUp = new AccountSignUpRequest
        //     {
        //         Username = username,
        //         Password = "123123",
        //         DateOfBirth = DateTime.Now
        //     };

        //     var response = _accountController.SignUp(accountSignUp);
        //     var resultContent = response.Result;

        //     Assert.IsInstanceOf<BadRequestResponse>(resultContent);
        // }
    }
}