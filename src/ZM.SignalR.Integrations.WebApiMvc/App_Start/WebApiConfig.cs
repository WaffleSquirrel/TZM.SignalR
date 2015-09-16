using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using System.Web.Http.ValueProviders;
using ZM.SignalR.Integrations.WebApiMvc.Models;
using ZM.SignalR.Integrations.WebApiMvc.Models.Binders;
using ZM.SignalR.Integrations.WebApiMvc.Models.ValueProviders;

namespace ZM.SignalR.Integrations.WebApiMvc
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "HumanActions",
                routeTemplate: "api/humans/{action}/{humanId}/{guessedNumber}",
                defaults: new { controller = "humans", humanId = RouteParameter.Optional, guessedNumber = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "InventoryActions",
                routeTemplate: "api/inventory/{action}/{apiId}",
                defaults: new { controller = "inventory", apiId = RouteParameter.Optional }
            );

            // Web API model bindings
            config.Services.Add(typeof(ValueProviderFactory), new RequestHeaderValueProviderFactory());

            config.Services.Insert(
                typeof(ModelBinderProvider), 
                0, 
                new SimpleModelBinderProvider(typeof(HumanRequest), new HumanRequestBinder())
            );

            config.Services.Insert(
                typeof(ModelBinderProvider),
                0,
                new SimpleModelBinderProvider(typeof(ApiRequest), new ApiRequestBinder())
            );
        }
    }
}