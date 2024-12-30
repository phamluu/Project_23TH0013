using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_23TH0013.Startup))]
namespace Project_23TH0013
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
