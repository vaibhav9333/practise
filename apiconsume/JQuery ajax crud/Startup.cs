using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JQuery_ajax_crud.Startup))]
namespace JQuery_ajax_crud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
