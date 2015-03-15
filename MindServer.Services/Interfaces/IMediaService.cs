using System.Collections.Generic;
using MindServer.Domain.Entities;
using MindServer.Services.DataContracts;
using MindServer.Services.ViewModels;

namespace MindServer.Services.Interfaces
{
    public interface IMediaService
    {
        GetAllMediaApiResponse GetAllMediaApiResponse();
        IEnumerable<MediaPostViewModel> GetAllMediaItems();
        void CreateAudioFile(AudioFile audioFile);
        void UpdateAudioFile(long id, AudioFile audioFile);
        void DeleteAudioFile(AudioFile audioFile);
    }
}