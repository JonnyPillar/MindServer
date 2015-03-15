using MindServer.Domain.Entities;
using MindServer.Services.DataContracts;

namespace MindServer.Services.Interfaces
{
    public interface IUserService
    {
        void CheckUserExists(string emailAddress);
        void CheckUserDoesntExist(AccountSignUpRequest request);
        User GetUser(AccountLogInRequest logInRequest);
        User GetAdminUser(AdminLogInRequest logInRequest);
    }
}