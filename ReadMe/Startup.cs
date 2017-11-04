using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReadMe.Startup))]
namespace ReadMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
