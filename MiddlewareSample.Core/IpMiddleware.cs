using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewareSample.Core
{
    public class IpMiddleware
    {
        private readonly RequestDelegate _next;

        public IpMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var ipAddress = httpContext.Connection.RemoteIpAddress.ToString();
            httpContext.Response.Headers.Add("ip", ipAddress);
            return _next(httpContext);
        }
    }

    public static class IpMiddlewareExtensions
    {
        public static IApplicationBuilder UseIpMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IpMiddleware>();
        }
    }
}