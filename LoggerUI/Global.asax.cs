using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace LoggerUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Get objects.
            HttpContext context = base.Context;
            HttpResponse response = context.Response;
            // Complete.
           // base.CompleteRequest();
        }

        ///// <summary>
        ///// This method execute when session time expired
        ///// </summary>
        //protected void Session_End()
        //{
        //    Response.Redirect("~/Error/Index");
        //}

        void Application_Error()
        {
            Exception ex = this.Server.GetLastError().GetBaseException();
            FormsAuthentication.SignOut();
            this.Response.Redirect("~/Error/Index");
        }
    }
}