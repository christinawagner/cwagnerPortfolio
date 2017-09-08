using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cwagnerPortfolio.Startup))]
namespace cwagnerPortfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
