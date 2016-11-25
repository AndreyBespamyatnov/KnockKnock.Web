using Owin;
using System.Net.Http.Headers;
using System.Web.Http;
using KnockKnock.Web.Interfaces;
using KnockKnock.Web.Services.Fibanacci;
using KnockKnock.Web.Services.Reverse;
using KnockKnock.Web.Services.Triangle;
using Microsoft.Practices.Unity;

namespace KnockKnock.Web
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            var container = new UnityContainer();
            container.RegisterType<IReverseWordsService, ReverseWordsService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITriangleService, TriangleService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFibonacciService, FibonachiService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            config.MapHttpAttributeRoutes();

            // Configure Web API for self-host. 
            appBuilder.UseWebApi(config);
        }
    }
}