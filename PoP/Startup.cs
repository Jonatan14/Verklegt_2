using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoP.Startup))]
namespace PoP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
