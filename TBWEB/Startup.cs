using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TBWeb.Startup))]
namespace TBWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
