using System;
using System.Threading.Tasks;
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
            ViewBag.Title = "Find Stuff and Things";

            return View();
        }

        /// <summary>
        /// Returns the default view for displaying the Human Search Page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult HumanSearch()
        {
            return View();
        }

        /// <summary>
        /// Returns the default view for displaying the API Inventory Search Page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ApiSearch()
        {
            return View();
        }

        /// <summary>
        /// Sends a notification message from one connected Human to all the other connected Humans, if any.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SendMessageToHumans(string message)
        {
            const string messageFormatString = "[{0}]:> {1}";
            const string messageFormatString2 = "[{0}]:> {1} '{2}'";

            await this.Clients.All.Message(string.Format(messageFormatString, DateTime.Now.ToString("hh:mm:ss"), "Hey, you should know that another Human posted a message from a website page.Now you know, and knowing is half the battle."));
            await this.Clients.All.Message(string.Format(messageFormatString2, DateTime.Now.ToString("hh:mm:ss"), "Message from the Human: ", message));
            string.Format(messageFormatString, DateTime.Now.ToString("hh:mm:ss"), "Hola from the server.");

            return View();
        }
    }
}