using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCM.DAO;
using WebAppCM.Models;

namespace WebAppCM.Controllers.AppController
{
    public class AppController : Controller
    {
        private CMEntities db = new CMEntities();
        private DAOApp dao = new DAOApp();
        // GET: App
        [HttpGet]
        public ActionResult ListApp()
        {
            var items = db.Applications;
            return View(dao.GetAllApp());
        }

        // GET: App/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        private ApplicationUserManager UserManager
        {   get
            {   return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        // GET: App/Create
        [HttpGet]
        public ActionResult AppCreate(int id)
        {
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            if (user != null)
            {
                Application app = new Application();
                ViewBag.User = user;
                return View();
            };
            return RedirectToAction("Login", "Account");
        }

        // POST: App/Create
        [HttpPost]
        public ActionResult AppCreate(Application m)
        {
            //Application app = new Application()
            //{

            //}
            //db.Applications.Add(App);
            db.SaveChanges();
            return RedirectToAction("AppList");
        }

        // GET: App/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: App/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: App/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: App/Delete/5
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
