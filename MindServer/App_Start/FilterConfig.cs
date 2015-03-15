using System.Web.Mvc;
using MindServer.Filters;
using RequireHttpsAttribute = MindServer.Filters.RequireHttpsAttribute;

namespace MindServer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
            filters.Add(new RequreSecureConnectionFilter());
        }
    }
}