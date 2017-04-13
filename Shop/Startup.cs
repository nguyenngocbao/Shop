using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute("ShopConfig", typeof(Shop.Startup))]
namespace Shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
