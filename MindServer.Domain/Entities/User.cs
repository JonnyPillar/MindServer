using System;
using System.ComponentModel.DataAnnotations;
using MindServer.Domain.Entities.AbstractEntities;

namespace MindServer.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string SessionToken { get; set; }
        public bool IsLoggedIn { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}