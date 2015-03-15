using System;
using System.ComponentModel.DataAnnotations;
using MindServer.Domain.Entities.AbstractEntities;
using MindServer.Domain.Enums;

namespace MindServer.Services.ViewModels
{
    public class MediaPostViewModel
    {
        public MediaPostViewModel(MediaEntity mediaEntity)
        {
            FileName = mediaEntity.FileName;
            FileUrl = mediaEntity.FileUrl;
            Title = mediaEntity.Title;
            Duration = mediaEntity.Duration;
            Description = mediaEntity.Description;
            ThumbnailUrl = mediaEntity.ThumbnailUrl;
            ImageUrl = mediaEntity.ImageUrl;
            BaseColour = mediaEntity.BaseColour;
            MediaType = mediaEntity.MediaType;
        }

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
        public string BaseColour { get; set; }

        [Required]
        public MediaType MediaType { get; set; }
    }
}