using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BBallCamp.WebMVC.Startup))]
namespace BBallCamp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
