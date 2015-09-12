using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ZM.SignalR.Integrations.WebApiMvc.Infrastructure.Communication.Hubs
{
    [HubName("trace")]
    public class TraceBroadcaster : Hub
    {
    }
}