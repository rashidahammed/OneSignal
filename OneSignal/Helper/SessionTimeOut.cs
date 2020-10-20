using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OneSignal.Helper
{
    public class SessionTimeOut : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            string _Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string _Action = filterContext.ActionDescriptor.ActionName;
            string[] _ExceptionAction = { "Index:Login" };

            if (_ExceptionAction.Contains(String.Format("{0}:{1}", _Controller, _Action)))
            {
                return;
            }

            if (HttpContext.Current.Session["UserID"] != null)
                return;
            var redirectTarget = new RouteValueDictionary { { "action", "Index" }, { "controller", "Login" } };
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult { Data = "Session has been expired !, Please refresh your page." };
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(redirectTarget);
            }
        }
    }
}