using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(web.artimeagallery.com.Startup))]
namespace web.artimeagallery.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
