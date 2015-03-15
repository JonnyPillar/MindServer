using MindServer.Services.DataContracts.AbstractDataContracts;

namespace MindServer.Services.DataContracts
{
    public class AccountSignUpResponse : BaseResponseContract
    {
        public string SessionToken { get; set; }
    }
}