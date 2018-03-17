using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRMProject.Startup))]
namespace CRMProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
