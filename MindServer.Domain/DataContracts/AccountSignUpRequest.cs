using System;
using System.ComponentModel.DataAnnotations;

namespace MindServer.Domain.DataContracts
{
    public struct AccountSignUpRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}