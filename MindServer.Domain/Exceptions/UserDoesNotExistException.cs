using MindServer.Domain.Exceptions.AbstractExceptions;

namespace MindServer.Domain.Exceptions
{
    public class UserDoesNotExistException : MindServerException
    {
        public UserDoesNotExistException(string message) : base(message)
        {
        }

        public UserDoesNotExistException() : base("User Doesnt Exist")
        {
        }
    }
}