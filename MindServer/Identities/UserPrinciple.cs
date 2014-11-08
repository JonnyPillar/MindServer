using System.Security.Principal;

namespace MindServer.Identities
{
    public class UserPrinciple : IPrincipal
    {
        public UserPrinciple(IIdentity user)
        {
            Identity = user;
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public IIdentity Identity { get; private set; }
    }
}