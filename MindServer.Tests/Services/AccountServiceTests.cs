using NUnit.Framework;

namespace MindServer.Tests.Services
{
    [TestFixture]
    public class AccountServiceTests
    {
        //[SetUp]
        //public void SetUp()
        //{
        //    _mindServerDbContext = MockRepository.GenerateStub<MindServerDbContext>();
        //    _mindServerDbContext.Users = new FakeDbSet<User>();

        //    //_unitOfWork = MockRepository.GenerateStub<IUnitOfWork>();
        //    //_unitOfWork.Stub(x => x.UserRepository).Return(_userRepository);

        //    _userRepository = MockRepository.GenerateStub<IUserRepository>();

        //    _unitOfWork = new EFUnitOfWork(_mindServerDbContext);
        //    _accountService = new AccountService(_unitOfWork);
        //}

        //private IUnitOfWork _unitOfWork;
        //private MindServerDbContext _mindServerDbContext;
        //private IAccountService _accountService;
        //private IUserRepository _userRepository;

        //[Test]
        //public void UserSignUp_UserAlreadyExists_ReturnsResponseObjectContainsEmptySessionToken()
        //{
        //    var request = new AccountSignUpRequest
        //    {
        //        Username = "existingUser@test.com",
        //        Password = "123456"
        //    };

        //    var responseTask = _accountService.AccountSignUp(request);
        //    var response = responseTask.Result;

        //    Assert.IsNullOrEmpty(response.SessionToken);
        //}

        //[Test]
        //public void UserSignUp_UserAlreadyExists_ReturnsResponseObjectContainsErrorMessage()
        //{
        //    var request = new AccountSignUpRequest
        //    {
        //        Username = "existingUser@test.com",
        //        Password = "123456"
        //    };

        //    var responseTask = _accountService.AccountSignUp(request);
        //    var response = responseTask.Result;

        //    Assert.IsNotNullOrEmpty(response.ResponseContract);
        //}

        //[Test]
        //public void UserSignUp_UserAlreadyExists_ReturnsResponseObjectWithSuccessFalse()
        //{
        //    _mindServerDbContext.Users.Add(new User
        //    {
        //        EmailAddress = "existingUser@test.com"
        //    });

        //    //_unitOfWork.UserRepository.Stub(x => x.Exists(It.IsAny<Expression<Func<User, bool>>>()))
        //    //    .Return(true);

        //    var request = new AccountSignUpRequest
        //    {
        //        Username = "existingUser@test.com",
        //        Password = "123456"
        //    };

        //    var responseTask = _accountService.AccountSignUp(request);
        //    var response = responseTask.Result;

        //    Assert.IsFalse(response.Success);
        //}
    }
}