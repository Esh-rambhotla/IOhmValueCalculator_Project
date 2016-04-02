using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IOhmValueCalculator1.Startup))]
namespace IOhmValueCalculator1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
