using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication26_Boris
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            string[] pages = Directory.GetFiles(HttpContext.Current.Server.MapPath("/Views/Pages/"), "*.cshtml");
            foreach (string page in pages)
            {
                string PageName = Path.GetFileNameWithoutExtension(page);
                routes.MapRoute(
                    PageName, // Route name
                    PageName, // URL with parameters
                    new { controller = "Pages", action = "Index", param1 = Path.GetFileName(page) } // Parameter defaults
                );
            }

            routes.MapRoute(
                name: "Projects",
                url: "Projects/{action}/{param1}",
                defaults: new { controller = "Projects", action = "List", param1 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Spares",
                url: "Spares/{action}/{param1}",
                defaults: new { controller = "Spares", action = "List", param1 = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{param1}",
                defaults: new { controller = "Home", action = "Index", param1 = UrlParameter.Optional }
            );
        }
    }
}