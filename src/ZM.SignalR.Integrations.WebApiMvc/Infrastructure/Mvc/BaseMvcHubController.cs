using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ZM.SignalR.Integrations.WebApiMvc.Infrastructure.Mvc
{
    public abstract class BaseMvcHubController<THub> : Controller where THub : Hub
    {
        public IHubConnectionContext<dynamic> Clients { get; private set; }
        public IGroupManager Groups { get; private set; }

        protected BaseMvcHubController()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<THub>();

            this.Clients = hubContext.Clients;
            this.Groups = hubContext.Groups;
        }
    }
}