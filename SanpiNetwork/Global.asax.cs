using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace SanpiNetwork
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //PreSendRequestHeaders += Application_PreSendRequestHeaders;
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.Flush();
            }
        }
        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            if (Response.Headers != null)
            {
                Response.Headers.Remove("Server");
                Response.Headers.Remove("X-AspNet-Version");
                Response.Headers.Remove("Expires");
                Response.Headers.Remove("Cache-Control");
                Response.Headers.Remove("Connection");
                Response.Headers.Remove("access-control-allow-origin");
            }
        }
    }
}