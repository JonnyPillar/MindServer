using MindServer.Domain.DataContracts;
using MindServer.Domain.Entities;
using MindServer.Domain.Exceptions;
using MindServer.Services.Interfaces;
using MindServer.Services.Repository.Interfaces;

namespace MindServer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CheckUserExists(string emailAddress)
        {
            var userExist =
                _unitOfWork.UserRepository.Exists(x => x.EmailAddress.Equals(emailAddress));
            if (!userExist) throw new UserDoesNotExistException();
        }

        public void CheckUserDoesntExist(AccountSignUpRequest accountSignUpRequest)
        {
            var userExist =
                _unitOfWork.UserRepository.Exists(x => x.EmailAddress.Equals(accountSignUpRequest.Username));
            if (userExist) throw new UserAlreadyExistsException();
        }

        public User GetUser(AccountLogInRequest logInRequest)
        {
            var requestingUser =
                _unitOfWork.UserRepository.Single(x => x.EmailAddress.Equals(logInRequest.EmailAddress));
            if (requestingUser == null) throw new UserDoesNotExistException();
            return requestingUser;
        }
    }
}