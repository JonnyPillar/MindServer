using System;
using System.Web.Http;
using MindServer.Domain.Entities;
using MindServer.Services.Interfaces;

namespace MindServer.Controllers.Api
{
    public class AudioController : ApiController
    {
        private readonly IMediaService _mediaService;

        public AudioController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var response = _mediaService.GetAllMediaItems();
                return Ok(response);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] AudioFile mediaEntity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(); //Sure??
                }
                //_mediaService.CreateAudioFile(mediaEntity);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpPut]
        public IHttpActionResult Edit(int id, [FromBody] AudioFile audioFile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                //_mediaService.UpdateAudioFile(id, audioFile);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody] AudioFile audioFile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                //_mediaService.DeleteAudioFile(audioFile);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}