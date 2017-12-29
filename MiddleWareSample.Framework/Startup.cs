using System.Web.Http;
using Owin;

namespace MiddleWareSample.Framework
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIpMiddleware();
        }
    }
}