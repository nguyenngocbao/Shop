using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "Shop.Controllers" }
            );
            routes.MapRoute(
          name: "Add Cart",
          url: "themgiohang",
          defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
          namespaces: new[] { "Shop.Controllers" }
      );
            routes.MapRoute(
                name: "Product", url: "test-1",
                 defaults: new { controller = "Home", action = "Index" },
          namespaces: new[] { "Shop.Controllers" }


                );


        }
    }
}
