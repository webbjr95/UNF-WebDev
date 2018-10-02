using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UNF_WebDev.Startup))]
namespace UNF_WebDev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
