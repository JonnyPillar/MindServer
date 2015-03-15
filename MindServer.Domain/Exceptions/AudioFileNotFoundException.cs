using MindServer.Domain.Exceptions.AbstractExceptions;

namespace MindServer.Domain.Exceptions
{
    public class AudioFileNotFoundException : MindServerException
    {
        public AudioFileNotFoundException(string message) : base(message)
        {
        }
    }
}