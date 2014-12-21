namespace MindServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMediaEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AudioFiles", "FileUrl", c => c.String(nullable: false));
            AddColumn("dbo.AudioFiles", "Description", c => c.String(nullable: false));
            AddColumn("dbo.AudioFiles", "ThumbnailUrl", c => c.String(nullable: false));
            AddColumn("dbo.AudioFiles", "ImageUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AudioFiles", "ImageUrl");
            DropColumn("dbo.AudioFiles", "ThumbnailUrl");
            DropColumn("dbo.AudioFiles", "Description");
            DropColumn("dbo.AudioFiles", "FileUrl");
        }
    }
}
