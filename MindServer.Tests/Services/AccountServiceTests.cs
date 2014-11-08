using System;
using System.Threading.Tasks;
using MindServer.Domain.DataContracts;
using MindServer.Domain.Entities;
using MindServer.Services;
using MindServer.Services.Repository.DataLayer;
using Moq;
using NUnit.Framework;

namespace MindServer.Tests.Services
{
    [TestFixture]
    public class AccountServiceTests
    {
        [Test]
        public async Task UserSignUp_ValidModel_SessionTokenReturned()
        {
            var unitOfWork = new Mock<EFUnitOfWork>();
            unitOfWork.Setup(x => x.UserRepository.Create(It.IsAny<User>()));
            var accountService = new AccountService(unitOfWork.Object);

            var validRequest = new AccountSignUpRequest
            {
                Username = "test@testuser.com",
                Password = "testpass",
                DateOfBirth = DateTime.UtcNow
            };

            var result = await accountService.UserSignUp(validRequest);

            Assert.IsNotNullOrEmpty(result);
        }
    }
}