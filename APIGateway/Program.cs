using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIGateway.ExceptionHandling;
using APIGateway.Middlewares;
using Commons.ExceptionHandling.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace APIGateway {
    public class Program {
        public static void Main(string[] args) {
            new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .ConfigureAppConfiguration((hostingContext, config) => {
                   config
                       .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                       .AddJsonFile("appsettings.json", true, true)
                       .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                       .AddJsonFile("ocelot.json")
                       .AddEnvironmentVariables();
               })
               .ConfigureServices(s => {
                   s.AddOcelot();
               })
               .ConfigureLogging((hostingContext, logging) => {
                   //add your logging
               })
               .UseIISIntegration()
               .Configure(app => {
                   var config = new OcelotPipelineConfiguration {

                       PreErrorResponderMiddleware = async ( context, next) => {

                           try {
                               await next.Invoke();
                           } catch (BaseException ex) {
                               await CustomOcelotExceptionHandling.HandleExceptionAsync(context, ex);
                           }

                           await next.Invoke();
                       },

                       PreAuthenticationMiddleware = async (context, next) => {

                           TokenValidationMiddleware.ValidateToken(context?.DownstreamRequest?.Headers?.Authorization?.Parameter);

                           await next.Invoke();
                       }
                   };
                   app.UseOcelot(config).Wait();
               })
               .Build()
               .Run();
        }
    }
}
