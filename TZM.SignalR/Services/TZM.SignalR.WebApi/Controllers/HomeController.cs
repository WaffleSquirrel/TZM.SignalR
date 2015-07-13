using System.Web.Mvc;

namespace TZM.SignalR.WebApi.Controllers
{
    /// <summary>
    /// The home MVC controller for the Web API UI.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the default view for displaying the Home Page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page - TZM SignalR Web API";

            return View();
        }

        public ActionResult Human()
        {
            return View();
        }
    }
}