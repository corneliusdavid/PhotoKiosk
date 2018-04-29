using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhotoDirectory.Startup))]
namespace PhotoDirectory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
