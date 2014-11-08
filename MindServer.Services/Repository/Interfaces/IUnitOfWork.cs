using System;
using System.Threading.Tasks;
using MindServer.Domain.Entities;

namespace MindServer.Services.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User, long> UserRepository { get; }
        IRepository<AudioFile, long> AudioFileRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}