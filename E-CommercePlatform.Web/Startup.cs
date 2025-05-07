using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_CommercePlatform.Web.Startup))]
namespace E_CommercePlatform.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
