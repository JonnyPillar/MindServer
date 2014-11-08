using System.ComponentModel.DataAnnotations;

namespace MindServer.Domain.DataContracts
{
    public struct AccountLogInRequest
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}