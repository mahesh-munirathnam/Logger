using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LoggerUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "People",
                url: "People/Permission/{PersonId}",
                defaults: new { controller = "People", action = "Permission" }
            );
            routes.MapRoute(
                name: "Access",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Access", action = "Enter", id = UrlParameter.Optional }
            );
        }
    }
}