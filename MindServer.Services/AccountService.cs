using System.Threading.Tasks;
using MindServer.Domain.DataContracts;
using MindServer.Domain.Entities;
using MindServer.Services.Interfaces;
using MindServer.Services.Repository.Interfaces;
using MindServer.Services.Utils;

namespace MindServer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> UserSignUp(AccountSignUpRequest signUpRequest)
        {
            var passwordHasherUtil = new PasswordHashUtil();
            var sessionToken = SessionTokenUtil.GenerateSessionToken();
            var newUser = new User
            {
                EmailAddress = signUpRequest.Username,
                DateOfBirth = signUpRequest.DateOfBirth,
                PasswordHash = passwordHasherUtil.PasswordHash,
                PasswordSalt = passwordHasherUtil.PasswordSalt,
                IsAdmin = false,
                SessionToken = sessionToken
            };

            _unitOfWork.UserRepository.Create(newUser);
            await _unitOfWork.SaveChangesAsync();
            return sessionToken;
        }

        public async Task<string> UserLogIn(AccountLogInRequest logInRequest)
        {
            return null;
        }

        public async Task UserLogOut(AccountLogOutRequest logOutRequest)
        {
        }
    }
}