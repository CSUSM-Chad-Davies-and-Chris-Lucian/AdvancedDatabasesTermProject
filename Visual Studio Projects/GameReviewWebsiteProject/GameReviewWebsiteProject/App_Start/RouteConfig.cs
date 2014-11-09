//Chris Lucian & Chad Davies
//CS 643 Advanced Databases
//11/8/2014

using System.Web.Mvc;
using System.Web.Routing;

namespace GameReviewWebsiteProject
{
    //Class used by MVC to configure Routing
    public class RouteConfig
    {

        //Configured the default routing for the Model View Controller functionality
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Default rout for the site is GameReviews/Index
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "GameReviews", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}