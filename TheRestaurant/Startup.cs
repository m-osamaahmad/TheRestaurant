using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheRestaurant.Startup))]
namespace TheRestaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
