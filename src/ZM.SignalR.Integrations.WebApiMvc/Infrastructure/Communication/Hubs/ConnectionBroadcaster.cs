using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace ZM.SignalR.Integrations.WebApiMvc.Infrastructure.Communication.Hubs
{
    public class ConnectionBroadcaster : Hub
    {
        public override Task OnConnected()
        {
            const string broadcastMessageFormatString = "[NEW Connection] => Connection ID {0}";

            return base.Clients.All.Message(string.Format(broadcastMessageFormatString, Context.ConnectionId));
        }

        public Task Broadcast(string message)
        {
            const string broadcastMessageFormatString = "[{0}] => {1}";

            return base.Clients.All.Message(string.Format(broadcastMessageFormatString, Context.ConnectionId, message));
        }
    }
}