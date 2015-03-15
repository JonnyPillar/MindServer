using System.Data.Entity;
using MindServer.Domain.Entities;

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

        public System.Data.Entity.DbSet<MindServer.Domain.Entities.AbstractEntities.MediaEntity> MediaEntities { get; set; }
    }
}