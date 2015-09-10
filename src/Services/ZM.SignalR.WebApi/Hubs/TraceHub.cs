using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ZM.SignalR.WebApi.Hubs
{
    [HubName("trace")]
    public class TraceHub : Hub
    {
    }
}