using System;
using System.Web.Http;
using MindServer.Services.Interfaces;

namespace MindServer.Controllers
{
    public class MediaController : ApiController
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public IHttpActionResult GetMediaFiles()
        {
            try
            {
                var response = _mediaService.GetAllMedia();
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}