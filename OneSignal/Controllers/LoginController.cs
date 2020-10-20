using OneSignal.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BAL.Models;
using BAL;
using SAL;
using System.Web.Security;

namespace OneSignal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                LoginResponse result = new UserC().UserLogin(model.UserName, model.Password);
                if (result.LoginStatus == true)
                {
                    Session["UserID"] = result.UserID;
                    Session["RoleID"] = result.RoleID;
                    Session["FullName"] = result.FullName;
                    Session["LoginStatus"] = result.LoginStatus;

                    return RedirectToAction("Index", "Notification");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message != null)
                    {
                        error = error + ex.InnerException.Message.ToString();
                    }
                }
                ViewBag.error = "Please contact administrator. ";
            }
            return View(model);
        }

        public ActionResult LogoutConfirm()
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
                FormsAuthentication.SignOut();
                Session.Remove("UserID");
                Session.Remove("RoleID");
                Session.Remove("FullName");
                Session.Remove("LoginStatus");
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                string ErrorMessage = ex.Message.ToString();
                if (ex.InnerException != null)
                {
                    if (ex.InnerException.Message != null)
                    {
                        ErrorMessage = ErrorMessage + ex.InnerException.Message.ToString();
                    }
                }
                ViewData["Error"] = ErrorMessage;
                return View("_ShowError");
            }
        }
    }


}
