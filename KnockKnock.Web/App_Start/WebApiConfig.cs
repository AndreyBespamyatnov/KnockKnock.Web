using System.Net.Http.Headers;
using System.Web.Http;
using KnockKnock.Web.Interfaces;
using KnockKnock.Web.Services;
using KnockKnock.Web.Services.Fibanacci;
using KnockKnock.Web.Services.Reverse;
using KnockKnock.Web.Services.Triangle;
using Microsoft.Practices.Unity;

namespace KnockKnock.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IReverseWordsService, ReverseWordsService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITriangleService, TriangleService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFibonachiService, FibonachiService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
