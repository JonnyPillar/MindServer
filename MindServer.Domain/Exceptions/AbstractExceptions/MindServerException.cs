using System;

namespace MindServer.Domain.Exceptions.AbstractExceptions
{
    public abstract class MindServerException : Exception
    {
        protected MindServerException(string message) : base(message)
        {
        }

        protected MindServerException()
        {
        }

        public override string Message
        {
            get { return base.Message; }
        }
    }
}