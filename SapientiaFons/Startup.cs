using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SapientiaFons.Startup))]
namespace SapientiaFons
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
