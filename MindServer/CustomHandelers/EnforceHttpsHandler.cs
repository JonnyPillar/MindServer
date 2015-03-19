using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MindServer.CustomHandelers
{
    public class EnforceHttpsHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // if request is local, just serve it without https
            object httpContextBaseObject;
            if (request.Properties.TryGetValue("MS_HttpContext", out httpContextBaseObject))
            {
                var httpContextBase = httpContextBaseObject as HttpContextBase;

                if (httpContextBase != null && httpContextBase.Request.IsLocal)
                {
                    return base.SendAsync(request, cancellationToken);
                }
            }

            if (request.Headers.Contains("X-Forwarded-Proto"))
            {
                var uriScheme = Convert.ToString(request.Headers.GetValues("X-Forwarded-Proto").First());
                if (string.Equals(uriScheme, "https", StringComparison.InvariantCultureIgnoreCase))
                {
                    return base.SendAsync(request, cancellationToken);                    
                }
            }

            // if request is remote, enforce https
            if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                return Task<HttpResponseMessage>.Factory.StartNew(
                () =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                    {
                        Content = new StringContent("HTTPS Required, URI Scheme: " + request.RequestUri.Scheme)
                    };

                    return response;
                });
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}