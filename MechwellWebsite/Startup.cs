using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MechwellWebsite.Startup))]
namespace MechwellWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
