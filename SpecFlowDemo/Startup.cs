using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpecFlowDemo.Startup))]
namespace SpecFlowDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
