using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using MindServer.Identities;
using MindServer.Services.Interfaces;

namespace MindServer.Filters
{
    public class UserAuthentication : AuthorizationFilterAttribute
    {
        private readonly IAccountService _accountService;

        public UserAuthentication(IAccountService accountService)
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
            catch (Exception)
            {
                actionContext.Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}