using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XETHome.Startup))]
namespace XETHome
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
