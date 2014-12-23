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
            context.Users.AddOrUpdate(new User
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
            context.Users.AddOrUpdate(new User
            {
                Id = 2,
                EmailAddress = "test@test.com",
                DateOfBirth = DateTime.UtcNow,
                IsAdmin = true,
                PasswordHash = "71B58E6C23CB9247A0E9B96CCFF88E249B7AEDA9A4197E7BEA0E906F7A4986CC",
                PasswordSalt = "5AC00FE09CF233D7577E410A8EF754930AD97D44B71DF02E970815DBB4747DE7",
                IsLoggedIn = false,
                SessionToken = "AF159851A2D82859A4EA783DC52C02CE5268AFA9E0A4AA1D068DE142DFAC7546"
            });

            context.AudioFiles.AddOrUpdate(
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

            context.AudioFiles.AddOrUpdate(
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

            context.AudioFiles.AddOrUpdate(
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