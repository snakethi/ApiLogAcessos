using LocalDBInterfaces.Inferfaces_LocalDB;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApiLogAcessos
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            ILocalDB_EndPoints LEndPoints = new LocalDB_EndPoints();

            LEndPoints.SetaConexao();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
