using System.ComponentModel.DataAnnotations;

namespace MindServer.Domain.DataContracts
{
    public class AdminLogInRequest
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }

        public bool Success { get; set; }
    }
}