using System.Threading.Tasks;
using MindServer.Domain.DataContracts;

namespace MindServer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> UserSignUp(AccountSignUpRequest signUpRequest);
        Task<string> UserLogIn(AccountLogInRequest logInRequest);
        Task UserLogOut(AccountLogOutRequest logOutRequest);
    }
}