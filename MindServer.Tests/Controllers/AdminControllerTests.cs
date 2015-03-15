using System;
using System.Web.Http.Results;
using MindServer.ActionResults;
using MindServer.Controllers;
using MindServer.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace MindServer.Tests.Controllers
{
    [TestFixture]
    internal class AdminControllerTests
    {
        //[SetUp]
        //public void SetUp()
        //{
        //    _mockAccountService = new Mock<IAccountService>();
        //    _accountController = new AdminController(_mockAccountService.Object);
        //}

        //private Mock<IAccountService> _mockAccountService;
        //private AdminController _accountController;

        //[Test]
        //public async void Index_AccountServiceReturnesUnSuccessFullResponse_BadRequestResonseReturned()
        //{
        //    _mockAccountService.Setup(x => x.AdminLogin(It.IsAny<AdminLogInRequest>()))
        //        .ReturnsAsync(new AdminLogInResponse
        //        {
        //            Success = false
        //        });

        //    var accountSignUp = new AdminLogInRequest
        //    {
        //        EmailAddress = "testUser@test.com",
        //        Password = "123123",
        //    };

        //    var response = await _accountController.LogIn(accountSignUp);
        //    var responseContent = response;

        //    Assert.IsInstanceOf<BadRequestResponse>(responseContent);
        //}

        //[Test]
        //public void Index_AccountServiceThrowsException_ExceptionResponseResonseReturned()
        //{
        //    _mockAccountService.Setup(x => x.AdminLogin(It.IsAny<AdminLogInRequest>()))
        //        .Throws(new Exception());

        //    var accountSignUp = new AdminLogInRequest
        //    {
        //        EmailAddress = "testUser@test.com",
        //        Password = "123123",
        //    };

        //    var response = _accountController.LogIn(accountSignUp);
        //    var responseContent = response.Result;

        //    Assert.IsInstanceOf<ExceptionResult>(responseContent);
        //}

        //[Test]
        //[TestCase(null)]
        //[TestCase("")]
        //public void Index_InvalidModelInvalidEmailAddress_BadRequestResponseReturned(string emailAddress)
        //{
        //    var accountSignUp = new AdminLogInRequest
        //    {
        //        EmailAddress = emailAddress,
        //        Password = "123123",
        //    };

        //    var response = _accountController.LogIn(accountSignUp);
        //    var resultContent = response.Result;

        //    Assert.IsInstanceOf<BadRequestResult>(resultContent);
        //}

        //[Test]
        //[TestCase(null)]
        //[TestCase("")]
        //public void Index_InvalidModelInvalidPassword_BadRequestResponseReturned(string password)
        //{
        //    var accountSignUp = new AdminLogInRequest
        //    {
        //        EmailAddress = "testUser@test.com",
        //        Password = password,
        //    };

        //    var response = _accountController.LogIn(accountSignUp);
        //    var resultContent = response.Result;

        //    Assert.IsInstanceOf<BadRequestResult>(resultContent);
        //}
    }
}