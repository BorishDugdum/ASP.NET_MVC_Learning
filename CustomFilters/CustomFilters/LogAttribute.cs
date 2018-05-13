using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace CustomFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Trace(MethodBase.GetCurrentMethod().Name, filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Trace(MethodBase.GetCurrentMethod().Name, filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Trace(MethodBase.GetCurrentMethod().Name, filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Trace(MethodBase.GetCurrentMethod().Name, filterContext.RouteData);
        }

        private void Trace(string methodName, System.Web.Routing.RouteData routeData)
        {
            string controllerName = routeData.Values["controller"].ToString();
            string actionMethodName = routeData.Values["action"].ToString();
            HttpContext.Current.Response.Write(
                $"MethodName={methodName}, " +
                $"Controller={controllerName}, " +
                $"Action={actionMethodName} <br><br>");
        }
    }
}