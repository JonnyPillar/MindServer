using System.Data.Entity.Migrations;

namespace MindServer.EF.Migrations
{
    public partial class AddedorderandanabledfieldtoMediafiles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AudioFiles", "Order", c => c.Int(false));
            AddColumn("dbo.AudioFiles", "Enabled", c => c.Boolean(false));
        }

        public override void Down()
        {
            DropColumn("dbo.AudioFiles", "Enabled");
            DropColumn("dbo.AudioFiles", "Order");
        }
    }
}