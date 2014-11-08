using System;
using System.Threading.Tasks;
using MindServer.Domain.DataContracts;
using MindServer.Domain.Entities;
using MindServer.Services;
using MindServer.Services.Repository;
using MindServer.Services.Repository.DataLayer;
using MindServer.Services.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using MockRepository = Rhino.Mocks.MockRepository;

namespace MindServer.Tests.Services
{
    //[TestFixture]
    //public class AccountServiceTests
    //{
    //    private IUserRepository userRepository;
    //    private IAudioFileRepository audioFileRepository;
    //    private IUnitOfWork unitOfWork;

    //    [SetUp]
    //    public void SetUp()
    //    {
            
    //    }


    //    [Test]
    //    public async Task UserSignUp_ValidModel_SessionTokenReturned()
    //    {


            
    //        var unitOfWorks = MockRepository.GenerateStub<IUnitOfWork>();



    //        //var userRepository = new Mock<UserRepository>().SetupAllProperties();
    //        //userRepository.Setup(x => x.Create(It.IsAny<User>()));
    //        //var audioFileRepository = new Mock<AudioFileRepository>();

    //        //var unitOfWork = new Mock<EFUnitOfWork>(userRepository.Object, audioFileRepository.Object);
    //        //var accountService = new AccountService(unitOfWork.Object);

    //        //var validRequest = new AccountSignUpRequest
    //        //{
    //        //    Username = "test@testuser.com",
    //        //    Password = "testpass",
    //        //    DateOfBirth = DateTime.UtcNow
    //        //};

    //        //var result = await accountService.UserSignUp(validRequest);

    //        //unitOfWork.Verify(x => x.UserRepository.Create(It.IsAny<User>()));
    //        //Assert.IsNotNullOrEmpty(result);
    //    }
    //}
}