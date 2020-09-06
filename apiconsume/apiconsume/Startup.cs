using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(apiconsume.Startup))]
namespace apiconsume
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
