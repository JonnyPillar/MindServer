using System;
using System.Web.Http;
using MindServer.Domain.DataContracts;
using MindServer.Services.Repository.Interfaces;

namespace MindServer.Controllers
{
    public class MediaController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public MediaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult GetMediaFiles()
        {
            try
            {
                var mediaFileList = _unitOfWork.AudioFileRepository.Get();
                var getMediaResponse = new GetMediaResponse
                {
                    Success = true,
                    MediaFiles = mediaFileList
                };
                return Ok(getMediaResponse);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}