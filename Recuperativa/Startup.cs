using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Recuperativa.Startup))]
namespace Recuperativa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
