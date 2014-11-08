namespace MindServer.Domain.DataContracts
{
    public struct AccountSignUpResponse
    {
        public bool Success { get; set; }
        public string SessionToken { get; set; }
    }
}