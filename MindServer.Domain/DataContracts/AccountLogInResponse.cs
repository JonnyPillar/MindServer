namespace MindServer.Domain.DataContracts
{
    public struct AccountLogInResponse
    {
        public bool Success { get; set; }
        public string SessionToken { get; set; }
    }
}