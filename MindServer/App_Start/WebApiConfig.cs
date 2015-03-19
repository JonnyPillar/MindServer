using System.Web.Http;
using MindServer.CustomHandelers;
using MindServer.Filters;

namespace MindServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new EnforceHttpsHandler());
            config.Filters.Add(new RequireHttpsApiAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}",
                new {action = RouteParameter.Optional, id = RouteParameter.Optional}
                );

        }
    }
}   