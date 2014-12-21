using MindServer.Domain.Exceptions.AbstractExceptions;

namespace MindServer.Domain.Exceptions
{
    public class InvalidSessionTokenException : MindServerException
    {
        public InvalidSessionTokenException(string message) : base(message)
        {
        }

        public InvalidSessionTokenException() : this("Invalid Session Token")
        {
        }
    }
}