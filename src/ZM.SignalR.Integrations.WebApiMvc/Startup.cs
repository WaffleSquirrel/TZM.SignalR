using Microsoft.Owin;
using Owin;
using ZM.SignalR.Integrations.WebApiMvc;

[assembly: OwinStartup(typeof(Startup))]

namespace ZM.SignalR.Integrations.WebApiMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}