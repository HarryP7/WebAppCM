using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppCM.Startup))]
namespace WebAppCM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
