using System.Web.Mvc;
using MindServer.Filters;

namespace MindServer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new RequireHttpsMvcAttribute());
            //filters.Add(new RequireHttpsApiAttribute());
            filters.Add(new RequreSecureConnectionFilter());
        }
    }
}