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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AudioFile> AudioFiles { get; set; }

        protected virtual void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<AudioFile>();
        }
    }
}