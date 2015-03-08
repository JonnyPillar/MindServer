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

        public void CheckUserDoesntExist(AccountSignUpRequest request)
        {
            var userExist =
                _unitOfWork.UserRepository.Exists(x => x.EmailAddress.Equals(request.Username));
            if (userExist) throw new UserAlreadyExistsException();
        }

        public User GetUser(AccountLogInRequest logInRequest)
        {
            if (!_unitOfWork.UserRepository.Exists(x => x.EmailAddress.Equals(logInRequest.EmailAddress)))
            {
                throw new UserDoesNotExistException();
            }
            return _unitOfWork.UserRepository.Single(x => x.EmailAddress.Equals(logInRequest.EmailAddress));
        }

        public User GetAdminUser(AdminLogInRequest logInRequest)
        {
            if (!_unitOfWork.UserRepository.Exists(x => x.EmailAddress.Equals(logInRequest.EmailAddress)))
            {
                throw new UserDoesNotExistException();
            }
            var user = _unitOfWork.UserRepository.Single(x => x.EmailAddress.Equals(logInRequest.EmailAddress));
            if (!user.IsAdmin) throw new UserNotAdminException();
            return user;
        }
    }
}