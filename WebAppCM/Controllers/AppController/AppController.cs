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

        // GET: App/Create
        [HttpGet]
        public ActionResult AppCreate()
        {
            return View();
        }

        // POST: App/Create
        [HttpPost]
        public ActionResult AppCreate(Application App)
        {
            db.Applications.Add(App);
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
