using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace EchoConnection
{
    public class EchoConnection : PersistentConnection
    {
        #region Fields

        private static int _connections = 0;

        #endregion

        #region Overrides

        protected override async Task OnConnected(IRequest request, string connectionId)
        {
            Interlocked.Increment(ref _connections);

            await Connection.Send(connectionId, string.Format("Welcome, {0}!", connectionId));
            await Connection.Broadcast(string.Format("New connection '{0}'. Current # of visitors: {1}", connectionId, _connections));
        }

        protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
        {
            Interlocked.Decrement(ref _connections);

            return Connection.Broadcast(string.Format("{0} closed. Current # of visitors: {1}", connectionId, _connections));
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var message = string.Format("{0} >> {1}", connectionId ,data);

            return Connection.Broadcast(message);
        }

        #endregion
    }
}