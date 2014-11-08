using MindServer.Domain.Entities.AbstractEntities;
using MindServer.Domain.Enums;

namespace MindServer.Domain.Entities
{
    public class AudioFile : MediaEntity
    {
        public AudioFile()
        {
            MediaType = MediaType.Audio;
        }
    }
}