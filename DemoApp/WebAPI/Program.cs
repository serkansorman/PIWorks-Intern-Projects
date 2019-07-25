using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI
{
    public class Program
    {
        static void Main(string[] args)
        {

            const string url = "http://localhost/";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server started at:" + url);
                Console.ReadLine();
            }
        }

        public class Startup
        {
            public void Configuration(IAppBuilder appBuilder)
            {
                EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");

                HttpConfiguration config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                                         "DefaultApi",
                                         "api/{controller}/{id}",
                                         new { id = RouteParameter.Optional }
                                        );

                config.EnableCors(cors);

                appBuilder.UseWebApi(config);
            }
        }
    }
}
