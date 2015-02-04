using System.Data.Entity.Migrations;

namespace MindServer.EF.Migrations
{
    public partial class Addedtitleanddurationtoaudiofile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AudioFiles", "Title", c => c.String(false));
            AddColumn("dbo.AudioFiles", "Duration", c => c.Time(false, 7));
        }

        public override void Down()
        {
            DropColumn("dbo.AudioFiles", "Duration");
            DropColumn("dbo.AudioFiles", "Title");
        }
    }
}