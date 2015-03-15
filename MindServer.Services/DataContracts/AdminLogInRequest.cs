using System.ComponentModel.DataAnnotations;

namespace MindServer.Services.DataContracts
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