using System;
using System.Collections.Generic;
using System.Linq;
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

                var response = new GetMediaResponse();
                foreach (var mediaItem in mediaItems)
                {
                    response.MediaFiles.Add(new GetMediaResponseItem(mediaItem));
                }
                response.Success = true;

                return response;
            }
            catch (Exception e)
            {
                return new GetMediaResponse
                {
                    Message = string.Format("Internal Error: {0}", e.Message)
                };
            }
        }
    }
}