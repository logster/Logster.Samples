using System.Web.Http;
using Logster.Samples.WebApi.Filters;

namespace Logster.Samples.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional}
                );

            config.MessageHandlers.Add(new LogMessageHandler());
        }
    }
}