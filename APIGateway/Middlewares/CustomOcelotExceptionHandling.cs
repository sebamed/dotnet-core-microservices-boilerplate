using Commons.ExceptionHandling.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APIGateway.ExceptionHandling {
    public class CustomOcelotExceptionHandling {

        public static Task HandleExceptionAsync(DownstreamContext context, BaseException ex) {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (ex is EntityNotFoundException) {
                code = HttpStatusCode.NotFound;
            } else if (ex is UnauthenticatedException) {
                code = HttpStatusCode.Unauthorized;
            }

            // actual response
            var result = JsonConvert.SerializeObject(new {
                messsage = ex.Message,
                status = code,
                requested_uri = context.HttpContext.Request.Path,
                origin = ex.origin,
                timestamp = DateTime.Now
            });

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;

            return context.HttpContext.Response.WriteAsync(result);
        }
    }

}
