using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using MindServer.Controllers;
using MindServer.Domain.Entities;
using MindServer.Domain.Enums;
using MindServer.Services.Repository.Interfaces;
using Moq;
using NUnit.Framework;

namespace MindServer.Tests.Controllers
{
    [TestFixture]
    public class MediaControllerTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        private MediaController _mediaController;

        [Test]
        public void GetMedia_FiveMockedMediaFiles_ReturnsListContainingAllFive()
        {
            int expectedNumberOfListElements = 3;
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.AudioFileRepository.Get()).Returns(new List<AudioFiles>
            {
                new AudioFiles
                {
                    Id = 1,
                    FileName = "File One",
                    MediaType = MediaType.Audio,
                },
                new AudioFiles
                {
                    Id = 2,
                    FileName = "File Two",
                    MediaType = MediaType.Audio,
                },
                new AudioFiles
                {
                    Id = 3,
                    FileName = "File Three",
                    MediaType = MediaType.Audio,
                }
            });

            _mediaController = new MediaController(unitOfWorkMock.Object);
            IHttpActionResult response = _mediaController.GetMediaFiles();
            var result = response as OkNegotiatedContentResult<List<AudioFiles>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfListElements, result.Content.Count);
        }
    }
}