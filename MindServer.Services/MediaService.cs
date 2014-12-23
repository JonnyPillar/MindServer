using System;
using System.Collections.Generic;
using MindServer.Domain.DataContracts;
using MindServer.Services.Interfaces;
using MindServer.Services.Repository.Interfaces;

namespace MindServer.Services
{
    public class MediaService : IMediaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MediaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetMediaResponse GetAllMedia()
        {
            try
            {
                var mediaItems = _unitOfWork.AudioFileRepository.Get();

                var response = new GetMediaResponse
                {
                    Success = true,
                    MediaFiles = new List<GetMediaResponseItem>()
                };

                foreach (var mediaItem in mediaItems)
                {
                    response.MediaFiles.Add(new GetMediaResponseItem(mediaItem));
                }

                return response;
            }
            catch (Exception e)
            {
                return new GetMediaResponse
                {
                    Success = false,
                    Message = string.Format("Internal Error: {0}", e.Message)
                };
            }
        }
    }
}