using System.Collections.Generic;
using MindServer.Services.DataContracts.AbstractDataContracts;

namespace MindServer.Services.DataContracts
{
    public class GetAllMediaApiResponse : BaseResponseContract
    {
        public GetAllMediaApiResponse()
        {
            MediaFiles = new List<GetMediaResponseItem>();
        }

        public List<GetMediaResponseItem> MediaFiles { get; set; }
    }
}