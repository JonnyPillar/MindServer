namespace MindServer.Domain.DataContracts.AbstractDataContracts
{
    public abstract class BaseResponseContract
    {
        protected BaseResponseContract()
        {
            Success = false;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}