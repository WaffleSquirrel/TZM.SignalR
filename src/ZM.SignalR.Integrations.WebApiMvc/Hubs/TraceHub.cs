using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ZM.SignalR.Integrations.WebApiMvc.Hubs
{
    [HubName("trace")]
    public class TraceHub : Hub
    {
    }
}