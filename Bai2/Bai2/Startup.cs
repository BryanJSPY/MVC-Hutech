using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bai2.Startup))]
namespace Bai2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
