using MindServer.Domain.Entities.AbstractEntities;
using MindServer.Domain.Enums;

namespace MindServer.Domain.Entities
{
    public class AudioMedia : MediaEntity
    {
        public AudioMedia()
        {
            MediaType = MediaType.Audio;
        }
    }
}