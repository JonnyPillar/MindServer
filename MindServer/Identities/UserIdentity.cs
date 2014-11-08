using System.Security.Principal;

namespace MindServer.Identities
{
    public class UserIdentity : IIdentity
    {
        public UserIdentity(string emailAddress)
        {
            Name = emailAddress;
            AuthenticationType = "Token";
            IsAuthenticated = true;
        }

        public string Name { get; private set; }
        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }
    }
}