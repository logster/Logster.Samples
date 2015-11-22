using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Logster.Samples.Web.Startup))]
namespace Logster.Samples.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
