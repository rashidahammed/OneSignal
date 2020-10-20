using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OneSignal.Helper
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public CustomAuthorizeAttribute()
        {

        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            try
            {
                bool? LoginStatus = Convert.ToBoolean(HttpContext.Current.Session["LoginStatus"]);
                if (LoginStatus != null && LoginStatus == true)
                {
                    authorize = true;
                }
            }
            catch (Exception e)
            {
                authorize = false;
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary { { "controller", "Login" }, { "action", "index" } });
        }
    }
}