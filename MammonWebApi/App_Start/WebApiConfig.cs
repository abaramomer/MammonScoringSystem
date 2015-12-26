using System.Web.Http;
using System.Web.Mvc;

namespace MammonWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ScoringSystemRoutes",
                routeTemplate: "api/ScoringSystem/{action}/{clientId}",
                defaults: new { action = "GetScores", clientId = UrlParameter.Optional}
            );
        }
    }
}
