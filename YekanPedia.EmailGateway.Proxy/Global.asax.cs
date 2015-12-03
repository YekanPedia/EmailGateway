using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using YekanPedia.EmailGateway.DependencyResolver;

namespace YekanPedia.EmailGateway.Proxy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IocInitializer.Initialize();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            IocInitializer.HttpContextDisposeAndClearAll();
        }
    }
}
