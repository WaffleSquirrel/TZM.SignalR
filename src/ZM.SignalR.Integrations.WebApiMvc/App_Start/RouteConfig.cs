using System.Web.Mvc;
using System.Web.Routing;

namespace ZM.SignalR.Integrations.WebApiMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HumanSearch",
                url: "home/human-search/{id}",
                defaults: new { controller = "Home", action = "HumanSearch", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ApiSearch",
                url: "home/api-search/{id}",
                defaults: new { controller = "Home", action = "ApiSearch", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}