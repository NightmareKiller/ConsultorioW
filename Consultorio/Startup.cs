using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Consultorio.Startup))]
namespace Consultorio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
