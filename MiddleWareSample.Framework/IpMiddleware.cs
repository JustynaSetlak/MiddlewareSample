using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Owin;

namespace MiddleWareSample.Framework
{
    public class IpMiddleware: OwinMiddleware
    {
        public IpMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override Task Invoke(IOwinContext context)
        {
            var ipAddress = (string) context.Request.Environment["server.RemoteIpAddress"];
            context.Response.Headers["IP address"] = ipAddress;
            return Next.Invoke(context);
        }
    }

    public static class IpMiddlewareExtensions
    {
        public static IAppBuilder UseIpMiddleware(this IAppBuilder builder)
        {
            return builder.Use(typeof(IpMiddleware));
        }
    }
}