using MindServer.Domain.Entities.AbstractEntities;
using MindServer.Domain.Enums;

namespace MindServer.Domain.Entities
{
    public class AudioFiles : MediaEntity
    {
        public AudioFiles()
        {
            MediaType = MediaType.Audio;
        }
    }
}