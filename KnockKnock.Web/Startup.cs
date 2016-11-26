using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Owin;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
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
            var container = new UnityContainer();
            container.RegisterType<IReverseWordsService, ReverseWordsService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITriangleService, TriangleService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFibonacciService, FibonachiService>(new HierarchicalLifetimeManager());

            HttpConfiguration config = new HttpConfiguration {DependencyResolver = new UnityResolver(container)};

            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            // Configure Web API for self-host. 
            appBuilder.UseWebApi(config);
        }

        public class UnhandledExceptionLogger : ExceptionLogger
        {
            public override void Log(ExceptionLoggerContext context)
            {
                var log = context.Exception.ToString();
                Trace.WriteLine(log);

#if DEBUG
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
#endif

                // TODO Log to logger
            }
        }

        public class GlobalExceptionHandler : ExceptionHandler
        {
            public override void Handle(ExceptionHandlerContext context)
            {
                context.Result = new TextPlainErrorResult
                {
                    Request = context.ExceptionContext.Request,
                    Content = "Oops! Sorry! Something went wrong." +
                              "Please contact adminsgz@gmail.com so we can try to fix it."
                };
            }

            public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
            {
                Handle(context);
                return Task.FromResult(0);
            }

            public override bool ShouldHandle(ExceptionHandlerContext context)
            {
                return context.ExceptionContext.CatchBlock.CallsHandler;
            }

            private class TextPlainErrorResult : IHttpActionResult
            {
                public HttpRequestMessage Request { get; set; }

                public string Content { get; set; }

                public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent(Content),
                        RequestMessage = Request
                    };
                    return Task.FromResult(response);
                }
            }
        }
    }
}