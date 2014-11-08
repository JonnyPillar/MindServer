using System.Data.Entity.Migrations;

namespace MindServer.EF.Migrations
{
    public partial class InitofDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AudioFile",
                c => new
                {
                    Id = c.Long(false, true),
                    FileName = c.String(false),
                    MediaType = c.Int(false),
                    CreatedDateTime = c.DateTime(false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Long(false, true),
                    EmailAddress = c.String(false),
                    DateOfBirth = c.DateTime(false),
                    PasswordHash = c.String(),
                    PasswordSalt = c.String(),
                    SessionToken = c.String(),
                    IsAdmin = c.Boolean(false),
                    CreatedDateTime = c.DateTime(false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.AudioFile");
        }
    }
}