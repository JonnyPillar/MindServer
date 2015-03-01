namespace MindServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBaseColourtoMediaEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AudioFiles", "BaseColour", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AudioFiles", "BaseColour");
        }
    }
}
