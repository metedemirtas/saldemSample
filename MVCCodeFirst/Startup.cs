using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCodeFirst.Startup))]
namespace MVCCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
