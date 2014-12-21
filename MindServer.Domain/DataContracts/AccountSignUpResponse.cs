using MindServer.Domain.DataContracts.AbstractDataContracts;

namespace MindServer.Domain.DataContracts
{
    public class AccountSignUpResponse : BaseResponseContract
    {
        public string SessionToken { get; set; }
    }
}