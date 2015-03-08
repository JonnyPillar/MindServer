using System.Threading.Tasks;
using MindServer.Domain.DataContracts;
using MindServer.Domain.Entities;
using MindServer.Domain.Exceptions;
using MindServer.Domain.Exceptions.AbstractExceptions;
using MindServer.Services.Interfaces;
using MindServer.Services.Repository.Interfaces;
using MindServer.Services.Utils;

namespace MindServer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public AccountService(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccountSignUpResponse> UserSignUp(AccountSignUpRequest accountSignUpRequest)
        {
            try
            {
                _userService.CheckUserDoesntExist(accountSignUpRequest);

                var sessionToken = await CreateNewUserAndGetSessionToken(accountSignUpRequest);

                return new AccountSignUpResponse
                {
                    Success = true,
                    SessionToken = sessionToken,
                    Message = "Registration Complete"
                };
            }
            catch (MindServerException e)
            {
                return new AccountSignUpResponse
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        public async Task<AccountLogInResponse> UserLogIn(AccountLogInRequest logInRequest)
        {
            try
            {
                var requestingUser = _userService.GetUser(logInRequest);

                var sessionToken = await LogUserInAndGetSessionToken(logInRequest, requestingUser);

                return new AccountLogInResponse
                {
                    Success = true,
                    SessionToken = sessionToken,
                    Message = "Log In Successful"
                };
            }
            catch (MindServerException e)
            {
                return new AccountLogInResponse
                {
                    Success = false,
                    Message = e.Message,
                };
            }
        }

        public async Task<AccountLogOutResponse> UserLogOut(AccountLogOutRequest logOutRequest)
        {
            try
            {
                _userService.CheckUserExists(logOutRequest.EmailAddress);

                await LogUserOut(logOutRequest);

                return new AccountLogOutResponse
                {
                    Success = true,
                    Message = "User Successfully Signed Out"
                };
            }
            catch (MindServerException e)
            {
                return new AccountLogOutResponse
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        public User AuthenticateSessionToken(string sessionToken)
        {
            var authenticatingUser = _unitOfWork.UserRepository.Single(x => x.SessionToken.Equals(sessionToken));
            if (authenticatingUser == null) throw new InvalidSessionTokenException();

            return authenticatingUser;
        }

        public async Task<AdminLogInResponse> AdminLogin(AdminLogInRequest logInRequest)
        {
            try
            {
                var user = _userService.GetAdminUser(logInRequest);

                ValidateUserPassword(logInRequest.Password, user);

                return new AdminLogInResponse
                {
                    Success = true,
                    Message = "Log In Successful"
                };
            }
            catch (MindServerException e)
            {
                return new AdminLogInResponse
                {
                    Success = false,
                    Message = e.Message,
                };
            }
        }

        private async Task LogUserOut(AccountLogOutRequest logOutRequest)
        {
            var requestingUser =
                _unitOfWork.UserRepository.Single(x => x.EmailAddress.Equals(logOutRequest.EmailAddress));

            requestingUser.IsLoggedIn = false;
            await _unitOfWork.SaveChangesAsync();
        }

        private async Task<string> LogUserInAndGetSessionToken(AccountLogInRequest logInRequest, User requestingUser)
        {
            ValidateUserPassword(logInRequest.Password, requestingUser);

            var sessionToken = UpdateUserToLoggedIn(requestingUser);

            await _unitOfWork.SaveChangesAsync();
            return sessionToken;
        }

        private static void ValidateUserPassword(string password, User requestingUser)
        {
            var passwordHashUtil = new PasswordHashUtil(password, requestingUser.PasswordSalt);
            if (!requestingUser.PasswordHash.Equals(passwordHashUtil.PasswordHash))
            {
                throw new UserAuthenticationException();
            }
        }

        private static string UpdateUserToLoggedIn(User requestingUser)
        {
            var sessionToken = SessionTokenUtil.GenerateSessionToken();
            requestingUser.SessionToken = sessionToken;
            requestingUser.IsLoggedIn = true;
            return sessionToken;
        }

        private async Task<string> CreateNewUserAndGetSessionToken(AccountSignUpRequest accountSignUpRequest)
        {
            var passwordHasherUtil = new PasswordHashUtil(accountSignUpRequest.Password);
            var sessionToken = SessionTokenUtil.GenerateSessionToken();
            var newUser = new User
            {
                EmailAddress = accountSignUpRequest.Username,
                DateOfBirth = accountSignUpRequest.DateOfBirth,
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
    }
}