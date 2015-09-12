using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ZM.SignalR.Integrations.WebApiMvc.Infrastructure.WebApi
{
    public abstract class BaseWebApiHubController<THub> : ApiController where THub : Hub
    {
        public IHubConnectionContext<dynamic> Clients { get; private set; }
        public IGroupManager Groups { get; private set; }

        protected BaseWebApiHubController()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<THub>();

            this.Clients = hubContext.Clients;
            this.Groups = hubContext.Groups;
        }
    }
}