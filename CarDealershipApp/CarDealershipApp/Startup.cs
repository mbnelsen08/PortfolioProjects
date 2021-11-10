using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarDealershipApp.Startup))]
namespace CarDealershipApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
