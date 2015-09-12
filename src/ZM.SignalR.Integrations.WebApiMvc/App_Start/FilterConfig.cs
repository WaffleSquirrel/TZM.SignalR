using System.Web.Mvc;

namespace ZM.SignalR.Integrations.WebApiMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}