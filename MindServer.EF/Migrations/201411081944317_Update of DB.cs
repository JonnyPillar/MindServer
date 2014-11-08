namespace MindServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateofDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsLoggedIn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsLoggedIn");
        }
    }
}
