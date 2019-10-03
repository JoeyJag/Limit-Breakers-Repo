using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Limit_Breakers_Repo.Startup))]
namespace Limit_Breakers_Repo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
