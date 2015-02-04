using System;
using System.ComponentModel.DataAnnotations;
using MindServer.Domain.Enums;

namespace MindServer.Domain.Entities.AbstractEntities
{
    public abstract class MediaEntity : BaseEntity
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public string FileUrl { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ThumbnailUrl { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public MediaType MediaType { get; set; }
    }
}