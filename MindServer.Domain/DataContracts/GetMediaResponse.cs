using System.Collections.Generic;
using MindServer.Domain.Entities;

namespace MindServer.Domain.DataContracts
{
    public struct GetMediaResponse
    {
        public bool Success { get; set; }
        public IEnumerable<AudioFile> MediaFiles { get; set; }
    }
}