using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using MindServer.Domain.Exceptions.AbstractExceptions;
using MindServer.Identities;
using MindServer.Services.Interfaces;

namespace MindServer.Filters
{
    public class UserAuthenticationFilter : AuthorizationFilterAttribute
    {
        private readonly IAccountService _accountService;

        public UserAuthenticationFilter(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                var authToken = actionContext.Request.Headers.GetValues("Authorization");

                if (authToken != null)
                {
                    var authenticatingUser = _accountService.AuthenticateSessionToken(authToken.First());
                    if (authenticatingUser != null)
                    {
                        actionContext.RequestContext.Principal =
                            new UserPrinciple(new UserIdentity(authenticatingUser.EmailAddress));
                    }
                }
                actionContext.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            catch (MindServerException e)
            {
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(e.Message)
                };
                httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                httpResponseMessage.RequestMessage = actionContext.Request;
                httpResponseMessage.StatusCode = HttpStatusCode.Unauthorized;

                actionContext.Request.CreateResponse(httpResponseMessage);
            }
            catch (Exception)
            {
                actionContext.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}