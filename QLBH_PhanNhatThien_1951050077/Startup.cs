using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLBH_PhanNhatThien_1951050077.Startup))]
namespace QLBH_PhanNhatThien_1951050077
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
