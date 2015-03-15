using System;
using System.Collections.Generic;
using System.Linq;
using MindServer.Domain.Entities;
using MindServer.Domain.Enums;
using MindServer.Services;
using MindServer.Services.Repository.Interfaces;
using Moq;
using NUnit.Framework;

namespace MindServer.Tests.Services
{
    [TestFixture]
    public class MediaServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mediaService = new MediaService(_mockUnitOfWork.Object);
        }

        private MediaService _mediaService;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [Test]
        public void GetAllMediaItems_ThreeMediaItemsInDb_ThreeViewModelsReturned()
        {
            _mockUnitOfWork.Setup(x => x.AudioFileRepository.Get()).Returns(new List<AudioFile>
            {
                new AudioFile
                {
                    Id = 1,
                    FileName = "One"
                },
                new AudioFile
                {
                    Id = 2,
                    FileName = "Two"
                },
                new AudioFile
                {
                    Id = 3,
                    FileName = "Three"
                }
            });

            var viewModels = _mediaService.GetAllMediaItems();

            Assert.That(viewModels.Count().Equals(3));
        }

        [Test]
        public void GetAllMediaItems_ZeroItemsInDb_EmptyListReturned()
        {
            _mockUnitOfWork.Setup(x => x.AudioFileRepository.Get()).Returns(new List<AudioFile>());

            var viewModels = _mediaService.GetAllMediaItems();

            Assert.IsEmpty(viewModels);
        }

        [Test]
        public void GetAllMedia_NoMediaItemsInDb_ResponseReturnsCorrectNumberOfItems()
        {
            _mockUnitOfWork.Setup(x => x.AudioFileRepository.Get()).Returns(new List<AudioFile>());

            var response = _mediaService.GetAllMediaApiResponse();

            Assert.AreEqual(0, response.MediaFiles.Count);
        }

        [Test]
        public void GetAllMedia_NoMediaItemsInDb_ResponseSuccessFlagIsTrue()
        {
            _mockUnitOfWork.Setup(x => x.AudioFileRepository.Get()).Returns(new List<AudioFile>());

            var response = _mediaService.GetAllMediaApiResponse();

            Assert.IsTrue(response.Success);
        }

        [Test]
        public void GetAllMedia_ThreeMediaItemsInDb_ResponseReturnsCorrectNumberOfItems()
        {
            _mockUnitOfWork.Setup(x => x.AudioFileRepository.Get()).Returns(new List<AudioFile>
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

            var response = _mediaService.GetAllMediaApiResponse();

            Assert.AreEqual(3, response.MediaFiles.Count);
        }

        [Test]
        public void GetAllMedia_ThreeMediaItemsInDb_ResponseSuccessFlagIsTrue()
        {
            _mockUnitOfWork.Setup(x => x.AudioFileRepository.Get()).Returns(new List<AudioFile>
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

            var response = _mediaService.GetAllMediaApiResponse();

            Assert.IsTrue(response.Success);
        }

        [Test]
        public void GetAllMedia_UnitOfWorkThrowsException_ResponseContainsErrorMessage()
        {
            _mockUnitOfWork.Setup(x => x.AudioFileRepository.Get()).Throws(new Exception());

            var response = _mediaService.GetAllMediaApiResponse();

            Assert.IsNotNullOrEmpty(response.Message);
        }

        [Test]
        public void GetAllMedia_UnitOfWorkThrowsException_ResponseMediaFilesListIsEmpty()
        {
            _mockUnitOfWork.Setup(x => x.AudioFileRepository.Get()).Throws(new Exception());

            var response = _mediaService.GetAllMediaApiResponse();

            Assert.IsEmpty(response.MediaFiles);
        }

        [Test]
        public void GetAllMedia_UnitOfWorkThrowsException_ResponseSuccessFlagIsFalse()
        {
            _mockUnitOfWork.Setup(x => x.AudioFileRepository.Get()).Throws(new Exception());

            var response = _mediaService.GetAllMediaApiResponse();

            Assert.IsFalse(response.Success);
        }
    }
}