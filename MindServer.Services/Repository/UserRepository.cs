using System.Data.Entity;
using MindServer.Domain.Entities;
using MindServer.Services.Repository.DataLayer;
using MindServer.Services.Repository.Interfaces;

namespace MindServer.Services.Repository
{
    public class UserRepository : EntityFrameworkRepository<User, int>, IUserRepository
    {
        public UserRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}