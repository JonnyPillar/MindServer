using System;
using MindServer.Domain.Entities.AbstractEntities;
using MindServer.Domain.Enums;

namespace MindServer.Domain.DataContracts
{
    public class GetMediaResponseItem
    {
        public GetMediaResponseItem(string fileName, string fileUrl, string description, string thumbnailUrl,
            string imageUrl, MediaType mediaType, string title, TimeSpan duration)
        {
            FileName = fileName;
            FileUrl = fileUrl;
            Description = description;
            ThumbnailUrl = thumbnailUrl;
            ImageUrl = imageUrl;
            MediaType = mediaType;
            Title = title;
            Duration = duration.ToString("g");
        }

        public GetMediaResponseItem(MediaEntity mediaEntity)
        {
            FileName = mediaEntity.FileName;
            FileUrl = mediaEntity.FileUrl;
            Description = mediaEntity.Description;
            ThumbnailUrl = mediaEntity.ThumbnailUrl;
            ImageUrl = mediaEntity.ImageUrl;
            MediaType = mediaEntity.MediaType;
            Title = mediaEntity.Title;
            Duration = mediaEntity.Duration.ToString("g");
        }

        public GetMediaResponseItem()
        {
        }

        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ImageUrl { get; set; }
        public MediaType MediaType { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
    }
}