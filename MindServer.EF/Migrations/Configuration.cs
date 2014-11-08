using System.Data.Entity.Migrations;

namespace MindServer.EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MindServerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MindServerDbContext context)
        {
        }
    }
}