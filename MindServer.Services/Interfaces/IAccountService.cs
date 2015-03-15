using System;
using System.Threading.Tasks;
using MindServer.Domain.Entities;
using MindServer.Services.DataContracts;

namespace MindServer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountSignUpResponse> UserSignUp(AccountSignUpRequest accountSignUpRequest);
        Task<AccountLogInResponse> UserLogIn(AccountLogInRequest logInRequest);
        Task<AccountLogOutResponse> UserLogOut(AccountLogOutRequest logOutRequest);
        Task<AdminLogInResponse> AdminLogin(AdminLogInRequest logInRequest);
        User AuthenticateSessionToken(string sessionToken);
    }
}