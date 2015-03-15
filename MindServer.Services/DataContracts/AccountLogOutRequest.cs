using System.ComponentModel.DataAnnotations;

namespace MindServer.Services.DataContracts
{
    public struct AccountLogOutRequest
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}