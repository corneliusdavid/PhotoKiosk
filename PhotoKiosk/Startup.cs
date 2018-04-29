using Microsoft.Owin;
using Owin;
using PhotoKiosk;

[assembly: OwinStartup(typeof(Startup))]
namespace PhotoKiosk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
