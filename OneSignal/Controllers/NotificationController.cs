using OneSignal.Helper;
using OneSignal.Models;
using SAL;
using SAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneSignal.Controllers
{
    [SessionTimeOut]
    [CustomAuthorize]
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            List<AppViewModel> Applist = new List<AppViewModel>();
            ViewBag.Permission = false;
            try
            {
                Applist = new comunication().GetAppList();
                int ROLEID = (int)EnumRole.Admin;
                ViewBag.Permission = Session["RoleID"].ToString() == ROLEID.ToString() ? true : false;
            }
            catch (Exception e)
            {

                //Writer excepton log
            }

            return View(Applist);
        }

        // GET: Notification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Notification/Create
        public ActionResult Create()
        {
       
            return View();
        }

        // POST: Notification/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddNewAppViewModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }

                AddNewApp request = new AddNewApp()
                {
                    name = collection.name,
                    apns_env = collection.apns_env,
                    apns_p12 = collection.apns_p12,
                    apns_p12_password = collection.apns_p12_password,
                    organization_id = collection.organization_id,
                    gcm_key = collection.gcm_key,
                    site_name= collection.site_name
                };

                new comunication().CreateNewApp(request);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Edit/5
        public ActionResult Edit(string id)
        {
           var response= new comunication().GetAppByAppID(id);
            return View(response);
        }

        // POST: Notification/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, AppViewModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(collection);
                }
                // TODO: Add update logic here
                UpdateApp request = new UpdateApp()
                {
                    name = collection.name,
                    apns_env = collection.apns_env,
                    apns_p12 = collection.safari_icon_128_128,
                    gcm_key = collection.gcm_key,
                   
                };


                var response = new comunication().UpdateApp(request,id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Notification/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
