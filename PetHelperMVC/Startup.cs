using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetHelperMVC.Startup))]
namespace PetHelperMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
