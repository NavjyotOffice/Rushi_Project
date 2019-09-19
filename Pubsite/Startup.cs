using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pubsite.Startup))]
namespace Pubsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
