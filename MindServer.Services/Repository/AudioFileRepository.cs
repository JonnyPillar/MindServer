using System.Data.Entity;
using MindServer.Domain.Entities;
using MindServer.Services.Repository.DataLayer;
using MindServer.Services.Repository.Interfaces;

namespace MindServer.Services.Repository
{
    public  class AudioFileRepository : EntityFrameworkRepository<AudioFiles, int>, IAudioFileRepository
    {
        public AudioFileRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}