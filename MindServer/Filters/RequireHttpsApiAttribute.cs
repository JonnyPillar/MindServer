using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MindServer.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class RequireHttpsApiAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException("actionContext");

            if (actionContext.Request.RequestUri.Scheme == Uri.UriSchemeHttps)
                return;

            if (actionContext.Request.Headers.Contains("X-Forwarded-Proto"))
            {
                var uriScheme = Convert.ToString(actionContext.Request.Headers.GetValues("X-Forwarded-Proto").First());
                if (string.Equals(uriScheme, "https", StringComparison.InvariantCultureIgnoreCase))
                    return;
            }

            if (actionContext.Request.IsLocal())
                return;

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }
}