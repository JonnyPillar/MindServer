using System.ComponentModel.DataAnnotations;
using MindServer.Domain.Enums;

namespace MindServer.Domain.Entities.AbstractEntities
{
    public abstract class MediaEntity : BaseEntity
    {
        [Required]
        public string FileName { get; set; }
        [Required]
        public MediaType MediaType { get; set; }
    }
}