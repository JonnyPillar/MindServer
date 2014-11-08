using MindServer.Controllers;
using MindServer.Domain.DataContracts;
using MindServer.Services.Interfaces;
using MindServer.Services.Utils;
using NUnit.Framework;

namespace MindServer.Tests.Controllers
{
    [TestFixture]
    public class AccountControllerTests
    {
        private IAccountService _accountService;
        private AccountController _accountController;

        //[Test]
        //public void SignUp_InvalidEmailAddressSignUpModel_BadRequestReturnedWithErrorMessage()
        //{
        //    var requestModel = new AccountSignUpRequest()
        //    {
                
        //    }
        //}

        [Test]
        public void SignUp_ValidSignUpModel_OkResponseReturnedWithSessionToken()
        {
            var temp = SessionTokenUtil.GenerateSessionToken();
        }
    }
}