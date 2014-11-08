using System;
using System.Data.Entity;
using System.Threading.Tasks;
using MindServer.Domain.Entities;
using MindServer.EF;
using MindServer.Services.Repository.Interfaces;

namespace MindServer.Services.Repository.DataLayer
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private IRepository<AudioFiles, int> _audioFilesRepository;
        private bool _disposed;
        private IRepository<User, int> _userRepository;

        public EFUnitOfWork()
        {
            _dbContext = new MindServerDbContext();
            _dbContext.Configuration.ValidateOnSaveEnabled = true;
        }

        public IRepository<User, int> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }

        public IRepository<AudioFiles, int> AudioFileRepository
        {
            get
            {
                if (_audioFilesRepository == null)
                {
                    _audioFilesRepository = new AudioFileRepository(_dbContext);
                }
                return _audioFilesRepository;
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}