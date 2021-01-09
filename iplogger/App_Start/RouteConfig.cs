using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace iplogger
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "newRoute",
               url: "{ name}",
               defaults: new { controller = "Home", action = "Index", name = UrlParameter.Optional }
               );

            routes.MapRoute(
               name: "newRoute2",
               url: "tracking/{ name}",
               defaults: new { controller = "Home", action = "tracking", name = UrlParameter.Optional }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
