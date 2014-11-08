using System;
using System.Threading.Tasks;
using MindServer.Domain.Entities;

namespace MindServer.Services.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User, int> UserRepository { get; }
        IRepository<AudioFiles, int> AudioFileRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}