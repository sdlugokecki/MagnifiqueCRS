using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MagnifiqueCRM.Startup))]
namespace MagnifiqueCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
