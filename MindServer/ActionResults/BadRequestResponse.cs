using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using MindServer.Domain.DataContracts.AbstractDataContracts;
using Newtonsoft.Json;

namespace MindServer.ActionResults
{
    public class BadRequestResponse : IHttpActionResult
    {
        public BadRequestResponse(HttpRequestMessage request, BaseResponseContract responseContract)
        {
            Request = request;
            ResponseContract = responseContract;
        }

        private BaseResponseContract ResponseContract { get; set; }

        private HttpRequestMessage Request { get; set; }


        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(JsonConvert.SerializeObject(ResponseContract)),
                RequestMessage = Request
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }
    }

    public static class ApiControllerExtensions
    {
        public static BadRequestResponse BadRequestResponse(this ApiController controller,
            BaseResponseContract responseContract)
        {
            return new BadRequestResponse(controller.Request, responseContract);
        }
    }
}