using System;
using System.Web.Http;
using MindServer.Domain.Entities.AbstractEntities;
using MindServer.Services.Interfaces;

namespace MindServer.Controllers.Api
{
    public class MediaController : ApiController
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet]
        [Route("GetMediaFiles")]
        public IHttpActionResult GetMediaFiles()
        {
            try
            {
                var response = _mediaService.GetAllMediaApiResponse();
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}