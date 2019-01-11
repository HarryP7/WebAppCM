using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCM.Models;

namespace WebAppCM.Controllers.AppController
{
    public class AppController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //private DAOApp dao = new DAOApp();
        // GET: App
        [HttpGet, Authorize(Roles = "Admin, Engineer,Castomer")]
        public ActionResult ListApp()
        {
            var items = db.Applications.Include(p => p.CadastralObject.HandBookOfCOType).Include(p => p.User).Include(p => p.Status).Include(p => p.TypeCW);
            return View(items);
        }

        // GET: App/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        private ApplicationUserManager UserManager{
            get{
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        // GET: App/Create
        [HttpGet, Authorize(Roles = "Admin, Engineer,Castomer")]
        public ActionResult AppCreate(int id)
        {
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            if (user != null)
            {
                ViewBag.User = user;
                // Формируем список типов КО для передачи в представление
                SelectList typeCO = new SelectList(db.HandBookOfCOTypes, "Id", "tHCOname");
                ViewBag.HandBookOfCOTypes = typeCO;
                // Формируем список типов КО для передачи в представление
                SelectList typeCW = new SelectList(db.TypeCWs, "Id", "tCWname");
                ViewBag.TypeCW = typeCW;
                ViewBag.Satus = 2;
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
        [HttpGet, Authorize(Roles = "Admin, Engineer,Castomer")]
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
        [HttpGet, Authorize(Roles = "Admin, Engineer,Castomer")]
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
