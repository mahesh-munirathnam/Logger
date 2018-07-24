using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;

namespace LoggerUI.Filters
{
    public class SessionFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            // TODO: Add your action filter's tasks here
            if (!Boolean.Parse(ConfigurationManager.AppSettings["IsDebug"]))
            {
                if(!(bool)filterContext.HttpContext.Session.Contents["UserID"])
                {
                    filterContext.Result = new RedirectToRouteResult(
                       new RouteValueDictionary
                       {
                            { "controller", "Error" },
                            { "action", "Index" }
                       });
                }
            }
            OnActionExecuting(filterContext);
        }
    }
}