using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using MindServer.Controllers;
using MindServer.Domain.DataContracts;
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
            const int expectedNumberOfListElements = 3;
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.AudioFileRepository.Get()).Returns(new List<AudioFile>
            {
                new AudioFile
                {
                    Id = 1,
                    FileName = "File One",
                    MediaType = MediaType.Audio,
                },
                new AudioFile
                {
                    Id = 2,
                    FileName = "File Two",
                    MediaType = MediaType.Audio,
                },
                new AudioFile
                {
                    Id = 3,
                    FileName = "File Three",
                    MediaType = MediaType.Audio,
                }
            });

            _mediaController = new MediaController(unitOfWorkMock.Object);
            var response = _mediaController.GetMediaFiles();
            var result = response as OkNegotiatedContentResult<GetMediaResponse>;

            Assert.IsNotNull(result);
            var resultContent = result.Content;
            Assert.IsTrue(resultContent.Success);
            Assert.AreEqual(expectedNumberOfListElements, resultContent.MediaFiles.Count());
        }

        [Test]
        public void GetMedia_ZeroMediaFiles_ReturnsSuccessWithListContainingNoElements()
        {
            const int expectedNumberOfListElements = 0;
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.AudioFileRepository.Get()).Returns(new List<AudioFile>());

            _mediaController = new MediaController(unitOfWorkMock.Object);
            var response = _mediaController.GetMediaFiles();
            var result = response as OkNegotiatedContentResult<GetMediaResponse>;

            Assert.IsNotNull(result);
            var resultContent = result.Content;
            Assert.IsTrue(resultContent.Success);
            Assert.AreEqual(expectedNumberOfListElements, resultContent.MediaFiles.Count());
        }
    }
}