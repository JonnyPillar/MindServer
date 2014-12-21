using System.Collections.Generic;
using MindServer.Domain.DataContracts.AbstractDataContracts;

namespace MindServer.Domain.DataContracts
{
    public class GetMediaResponse : BaseResponseContract
    {
        public GetMediaResponse()
        {
            MediaFiles = new List<GetMediaResponseItem>();
        }

        public List<GetMediaResponseItem> MediaFiles { get; set; }
    }
}