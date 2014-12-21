using MindServer.Domain.Exceptions.AbstractExceptions;

namespace MindServer.Domain.Exceptions
{
    public class UserAuthenticationException : MindServerException
    {
        public UserAuthenticationException(string message) : base(message)
        {
        }

        public UserAuthenticationException() : this("User Authentication Failed")
        {
        }
    }
}