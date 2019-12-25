using Commons.ExceptionHandling.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Commons.ExceptionHandling {
    public class ErrorHandlingMiddleware {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next) {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */) {
            try {
                await next(context);
            } catch (Exception ex) {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex) {
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
                requested_uri = context.Request.Path,
                timestamp = DateTime.Now
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }

    }
}
