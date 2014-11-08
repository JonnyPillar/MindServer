using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using MindServer.Domain.Entities;
using MindServer.Services.Repository.Interfaces;

namespace MindServer.Controllers
{
    public class MediaController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public MediaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IHttpActionResult GetMediaFiles()
        {
            var mediaFileList = _unitOfWork.AudioFileRepository.Get();
            return null;
        }
    }
}