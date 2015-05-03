using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MindServer.Domain.Entities;
using MindServer.Domain.Exceptions;
using MindServer.Services.DataContracts;
using MindServer.Services.Interfaces;
using MindServer.Services.Repository.Interfaces;
using MindServer.Services.ViewModels;

namespace MindServer.Services
{
    public class MediaService : IMediaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MediaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetAllMediaApiResponse GetAllMediaApiResponse()
        {
            try
            {
                var mediaItems = GetAllEnabledAudioFilesInOrder();

                var response = new GetAllMediaApiResponse();
                foreach (var mediaItem in mediaItems)
                {
                    response.MediaFiles.Add(new GetMediaResponseItem(mediaItem));
                }
                response.Success = true;

                return response;
            }
            catch (Exception e)
            {
                return new GetAllMediaApiResponse
                {
                    Message = string.Format("Internal Error: {0}", e.Message)
                };
            }
        }

        public IEnumerable<MediaPostViewModel> GetAllMediaItems()
        {
            var audioFiles = GetAllAudioFiles();
            var mediaPostViewModelsList = new List<MediaPostViewModel>();

            foreach (var audioFile in audioFiles)
            {
                mediaPostViewModelsList.Add(new MediaPostViewModel(audioFile));
            }

            return mediaPostViewModelsList;
        }

        public async Task<AudioFile> GetAudioFile(long id)
        {
            try
            {
                return await _unitOfWork.AudioFileRepository.GetAsync(id);
            }
            catch (InvalidOperationException e)
            {
                throw new AudioFileNotFoundException(e.Message);
            }
        }

        public void CreateAudioFile(AudioFile audioFile)
        {
            _unitOfWork.AudioFileRepository.Create(audioFile);
        }

        public void UpdateAudioFile(long id, AudioFile audioFile)
        {
            _unitOfWork.AudioFileRepository.Update(id, audioFile);
        }

        public void DeleteAudioFile(AudioFile audioFile)
        {
            _unitOfWork.AudioFileRepository.Delete(audioFile);
        }

        private IEnumerable<AudioFile> GetAllAudioFiles()
        {
            var mediaItems = _unitOfWork.AudioFileRepository.Get();
            return mediaItems;
        }

        private IEnumerable<AudioFile> GetAllEnabledAudioFilesInOrder()
        {
            var mediaItems = _unitOfWork.AudioFileRepository.Find(file => file.Enabled).OrderBy(file => file.Order);
            return mediaItems;
        }
    }
}