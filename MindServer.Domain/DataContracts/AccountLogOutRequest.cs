using System.ComponentModel.DataAnnotations;

namespace MindServer.Domain.DataContracts
{
    public struct AccountLogOutRequest
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}