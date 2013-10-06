using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventsSystem.Startup))]
namespace EventsSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
