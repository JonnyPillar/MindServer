using MindServer.Domain.Exceptions.AbstractExceptions;

namespace MindServer.Domain.Exceptions
{
    public class UserAlreadyExistsException : MindServerException
    {
        public UserAlreadyExistsException() : base("User Already Exists")
        {
        }

        public UserAlreadyExistsException(string message) : base(message)
        {
        }
    }
}