using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCM.Models;
using System.Data.Entity;

namespace WebAppCM.Controllers.CWController
{
    public class CWController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CW
        [HttpGet, Authorize(Roles = "Admin, Engineer")]
        public ActionResult ListCW()
        {
            var items = db.CadastralWorks.Include(p => p.User).Include(p => p.TypeCW);
            return View(items);
        }

        // GET: CW/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CW/Create
        public ActionResult CWCreate()
        {
            return View();
        }

        // POST: CW/Create
        [HttpPost]
        public ActionResult CWCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CW/Edit/5
        public ActionResult CWEdit(int id)
        {
            return View();
        }

        // POST: CW/Edit/5
        [HttpPost]
        public ActionResult CWEdit(int id, FormCollection collection)
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

        // GET: CW/Delete/5
        public ActionResult CWDelete(int id)
        {
            return View();
        }

        // POST: CW/Delete/5
        [HttpPost]
        public ActionResult CWDelete(int id, FormCollection collection)
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
