using MindServer.Domain.DataContracts;
using MindServer.Domain.Entities;

namespace MindServer.Services.Interfaces
{
    public interface IUserService
    {
        void CheckUserExists(string emailAddress);
        void CheckUserDoesntExist(AccountSignUpRequest accountSignUpRequest);
        User GetUser(AccountLogInRequest logInRequest);
    }
}