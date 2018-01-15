using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(apiLearn.Startup))]
namespace apiLearn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
