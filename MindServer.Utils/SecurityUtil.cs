using System.Security.Principal;
using MindServer.Domain.Entities;

namespace MindServer.Utils
{
    public static class SecurityUtil
    {
        /// <summary>
        ///     Is User Authenticated
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>True or False</returns>
        public static bool AuthenticUser(IPrincipal user)
        {
            return user.Identity.IsAuthenticated;
        }

        /// <summary>
        ///     Check Login Password Is Valid Against Expected Users Hash
        /// </summary>
        /// <param name="expectedUser">User In Question</param>
        /// <param name="enteredPassword">Inputted Password</param>
        /// <returns>Validity</returns>
        public static bool IsPasswordValid(User expectedUser, string enteredPassword)
        {
            var passwordHasher = new PasswordUtil(enteredPassword, expectedUser.PasswordSalt);
            return expectedUser.PasswordHash.Equals(passwordHasher.PasswordHash);
        }

        /// <summary>
        ///     Is a paassword entered by a user valid
        /// </summary>
        /// <param name="usersPasswordHash">Password Hash From DB</param>
        /// <param name="usersPasswordSalt">Password Salt From DB</param>
        /// <param name="passwordStringToCheck">Password Entered By User</param>
        /// <returns>Valid Password?</returns>
        public static bool IsPasswordValid(string passwordStringToCheck, string usersPasswordSalt,
            string usersPasswordHash)
        {
            var passwordHasher = new PasswordUtil(passwordStringToCheck, usersPasswordSalt);
            return passwordHasher.PasswordHash.Equals(usersPasswordHash);
        }
    }
}