using System.Data.Entity;
using MindServer.Domain.Entities;
using MindServer.Domain.Entities.AbstractEntities;

namespace MindServer.EF
{
    public class MindServerDbContext : DbContext
    {
        public MindServerDbContext()
            : base("name=MindServerDbContext")
        {
        }

        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<AudioFile> AudioFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<AudioFile>();
        }
    }
}