using System;
using System.Threading.Tasks;
using MindServer.Domain.DataContracts;
using MindServer.Domain.Entities;

namespace MindServer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountSignUpResponse> UserSignUp(AccountSignUpRequest accountSignUpRequest);
        Task<AccountLogInResponse> UserLogIn(AccountLogInRequest logInRequest);
        Task<AccountLogOutResponse> UserLogOut(AccountLogOutRequest logOutRequest);
        User AuthenticateSessionToken(string sessionToken);
    }
}