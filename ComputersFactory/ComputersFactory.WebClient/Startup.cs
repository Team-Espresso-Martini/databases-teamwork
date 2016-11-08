using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ComputersFactory.WebClient.Startup))]
namespace ComputersFactory.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
