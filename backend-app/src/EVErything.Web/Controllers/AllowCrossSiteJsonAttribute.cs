using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EVErything.Web.Controllers
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = filterContext.HttpContext;
            var origin = ctx.Request.Headers["Origin"];
            string allowOrigin = origin.ToString() != null ? origin.ToString() : "*";
            Console.WriteLine("allowOrigin:" + allowOrigin);
            ctx.Response.Headers.Add("Access-Control-Allow-Origin", allowOrigin);
            ctx.Response.Headers.Add("Access-Control-Allow-Headers", "*");
            ctx.Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            base.OnActionExecuting(filterContext);
        }

        //public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        //{
        //    if (actionExecutedContext.HttpContext.Response != null)
        //        actionExecutedContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

        //    base.OnActionExecuted(actionExecutedContext);
        //}

    }
}
