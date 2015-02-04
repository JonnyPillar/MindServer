using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using MindServer.Controllers;
using MindServer.Domain.DataContracts;
using MindServer.Domain.Entities;
using MindServer.Domain.Enums;
using MindServer.Services.Interfaces;
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
            _mockedMediaService = new Mock<IMediaService>();
            _mediaController = new MediaController(_mockedMediaService.Object);
        }

        private Mock<IMediaService> _mockedMediaService;
        private MediaController _mediaController;

        [Test]
        public void GetMediaFiles_MediaServiceThrowsExecption_ErrorResponseMessageReturned()
        {
            _mockedMediaService.Setup(x => x.GetAllMedia()).Throws(new Exception());

            var response = _mediaController.GetMediaFiles();

            Assert.IsInstanceOf<ExceptionResult>(response);
        }

        [Test]
        public void GetMediaFiles_ResponseObjectReturned_OkResponseReturned()
        {
            _mockedMediaService.Setup(x => x.GetAllMedia()).Returns(new GetMediaResponse());

            var response = _mediaController.GetMediaFiles();

            var result = response as OkNegotiatedContentResult<GetMediaResponse>;
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetMedia_FiveMockedMediaFiles_ReturnsListContainingAllFive()
        {
            const int expectedNumberOfListElements = 3;

            var userService = new Mock<IMediaService>();
            userService.Setup(x => x.GetAllMedia()).Returns(new GetMediaResponse
            {
                Success = true,
                MediaFiles = new List<GetMediaResponseItem>
                {
                    new GetMediaResponseItem(new AudioFile
                    {
                        Id = 1,
                        FileName = "File One",
                        MediaType = MediaType.Audio,
                    }),
                    new GetMediaResponseItem(new AudioFile
                    {
                        Id = 2,
                        FileName = "File Two",
                        MediaType = MediaType.Audio,
                    }),
                    new GetMediaResponseItem(new AudioFile
                    {
                        Id = 3,
                        FileName = "File Three",
                        MediaType = MediaType.Audio,
                    }),
                }
            });

            _mediaController = new MediaController(userService.Object);
            var response = _mediaController.GetMediaFiles();
            var result = response as OkNegotiatedContentResult<GetMediaResponse>;

            Assert.IsNotNull(result);
            var resultContent = result.Content;
            Assert.IsTrue(resultContent.Success);
            Assert.AreEqual(expectedNumberOfListElements, resultContent.MediaFiles.Count);
        }

        [Test]
        public void GetMedia_ZeroMediaFiles_ReturnsSuccessWithListContainingNoElements()
        {
            const int expectedNumberOfListElements = 0;
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.AudioFileRepository.Get()).Returns(new List<AudioFile>());

            var userService = new Mock<IMediaService>();
            userService.Setup(x => x.GetAllMedia()).Returns(new GetMediaResponse()
            {
                Success = true,
                MediaFiles = new List<GetMediaResponseItem>()
            });

            _mediaController = new MediaController(userService.Object);
            var response = _mediaController.GetMediaFiles();
            var result = response as OkNegotiatedContentResult<GetMediaResponse>;

            Assert.IsNotNull(result);
            var resultContent = result.Content;
            Assert.IsTrue(resultContent.Success);
            Assert.AreEqual(expectedNumberOfListElements, resultContent.MediaFiles.Count);
        }
    }
}