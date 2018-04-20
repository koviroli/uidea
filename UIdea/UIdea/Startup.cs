using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UIdea.Startup))]
namespace UIdea
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
