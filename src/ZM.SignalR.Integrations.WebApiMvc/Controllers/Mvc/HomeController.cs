using System.Web.Mvc;
using ZM.SignalR.Integrations.WebApiMvc.Infrastructure.Communication.Hubs;
using ZM.SignalR.Integrations.WebApiMvc.Infrastructure.Mvc;

namespace ZM.SignalR.Integrations.WebApiMvc.Controllers.Mvc
{
    /// <summary>
    /// The home MVC controller for the Web API UI.
    /// </summary>
    public class HomeController : BaseMvcHubController<ConnectionBroadcaster>
    {
        /// <summary>
        /// Returns the default view for displaying the Home Page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page - ZM SignalR Web Integrations";

            return View();
        }

        /// <summary>
        /// Returns the default view for displaying the Human Page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Human()
        {
            return View();
        }
    }
}