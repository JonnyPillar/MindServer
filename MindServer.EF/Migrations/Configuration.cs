using System;
using System.Collections.Generic;
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

            context.AudioFiles.AddRange(new List<AudioFile>
            {
                new AudioFile
                {
                    Id = 1,
                    FileName = "AudioFileOne.mp3",
                },
                new AudioFile
                {
                    Id = 2,
                    FileName = "AudioFileTwo.mp3",
                },
                new AudioFile
                {
                    Id = 3,
                    FileName = "AudioFileThree.mp3",
                }
            });
        }
    }
}