using MindServer.Services.DataContracts.AbstractDataContracts;

namespace MindServer.Services.DataContracts
{
    public class AccountLogInResponse : BaseResponseContract
    {
        public string SessionToken { get; set; }
    }
}