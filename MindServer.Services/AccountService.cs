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
            var userExist = _unitOfWork.UserRepository.Exists(x => x.EmailAddress.Equals(signUpRequest.Username));
            if (userExist) return null;

            var passwordHasherUtil = new PasswordHashUtil(signUpRequest.Password);
            var sessionToken = SessionTokenUtil.GenerateSessionToken();
            var newUser = new User
            {
                EmailAddress = signUpRequest.Username,
                DateOfBirth = signUpRequest.DateOfBirth,
                PasswordHash = passwordHasherUtil.PasswordHash,
                PasswordSalt = passwordHasherUtil.PasswordSalt,
                IsAdmin = false,
                IsLoggedIn = true,
                SessionToken = sessionToken
            };

            _unitOfWork.UserRepository.Create(newUser);
            await _unitOfWork.SaveChangesAsync();
            return sessionToken;
        }

        public async Task<string> UserLogIn(AccountLogInRequest logInRequest)
        {
            var requestingUser = _unitOfWork.UserRepository.Single(x => x.EmailAddress.Equals(logInRequest.EmailAddress));
            if (requestingUser != null)
            {
                var passwordHashUtil = new PasswordHashUtil(logInRequest.Password, requestingUser.PasswordSalt);
                if (requestingUser.PasswordHash.Equals(passwordHashUtil.PasswordHash))
                {
                    var sessionToken = SessionTokenUtil.GenerateSessionToken();
                    requestingUser.SessionToken = sessionToken;
                    requestingUser.IsLoggedIn = true;
                    await _unitOfWork.SaveChangesAsync();
                    return sessionToken;
                }
            }
            return null;
        }

        public async Task UserLogOut(AccountLogOutRequest logOutRequest)
        {
            var requestingUser =
                _unitOfWork.UserRepository.Single(x => x.EmailAddress.Equals(logOutRequest.EmailAddress));
            if (requestingUser != null)
            {
                requestingUser.IsLoggedIn = false;
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}