using System;
using System.Data.Entity.Migrations;
using MindServer.Domain.Entities;

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
            context.Users.Add(new User
            {
                Id = 1,
                EmailAddress = "jonny@jonnypillar.co.uk",
                DateOfBirth = DateTime.UtcNow,
                IsAdmin = true,
                PasswordHash = "C32BC5EF6DA4C72F4D33E2DF40AC44D80060E03B4B5CCBCA4E24468B3779DD3E",
                PasswordSalt = "42D24B564859E3FFB0DBED4CAC1EBBB39390E481BA509DB709FE30FB50C70BD4",
                IsLoggedIn = false,
                SessionToken = "B802AD94EE7F4E80A808B8EF8E60C1A3B28619A7E36C352C326173FE6062853C"
            });

            context.AudioFiles.Add(
                new AudioFile
                {
                    Id = 1,
                    FileName = "AwardTour.mp3",
                    FileUrl = "https://s3-eu-west-1.amazonaws.com/mindmediafiles/AwardTour.mp3",
                    Description = "Award Tour",
                    ThumbnailUrl = "http://mind.jonnypillar.co.uk/Windows_Media_Player_alt.png",
                    ImageUrl = "http://mind.jonnypillar.co.uk/Windows_Media_Player_alt.png",
                    MediaType = 0
                });

            context.AudioFiles.Add(
                new AudioFile
                {
                    Id = 2,
                    FileName = "TakeFive.mp3",
                    FileUrl = "https://s3-eu-west-1.amazonaws.com/mindmediafiles/Dave+Brubeck+-+Take+Five.mp3",
                    Description = "Take Five",
                    ThumbnailUrl = "http://mind.jonnypillar.co.uk/Windows_Media_Player_alt.png",
                    ImageUrl = "http://mind.jonnypillar.co.uk/Windows_Media_Player_alt.png",
                    MediaType = 0
                });

            context.AudioFiles.Add(
                new AudioFile
                {
                    Id = 3,
                    FileName = "ShakeItOut.mp3",
                    FileUrl = "https://s3-eu-west-1.amazonaws.com/mindmediafiles/Taylor+Swift+-+Shake+It+Off.mp3",
                    Description = "Shake It Out",
                    ThumbnailUrl = "http://mind.jonnypillar.co.uk/Windows_Media_Player_alt.png",
                    ImageUrl = "http://mind.jonnypillar.co.uk/Windows_Media_Player_alt.png",
                    MediaType = 0
                });
        }
    }
}