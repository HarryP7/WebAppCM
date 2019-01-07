using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCM.DAO;
using WebAppCM.Models;

namespace WebAppCM.Controllers.COController
{
    public class COController : Controller
    {
        private CMEntities db = new CMEntities();
        private DAOCadastralObject dao = new DAOCadastralObject();
        // GET: CO
        public ActionResult ListCO()
        {
            var items = db.CadastralObjects;
            items.ToList();
            return View(dao.GetAllCO());
        }

        // GET: CO/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CO/Create
        [HttpPost]
        public ActionResult COCreate(FormCollection collection)
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

        // GET: CO/Edit/5
        [HttpGet]
        public ActionResult COEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            CadastralObject co = db.CadastralObjects.Find(id);
            if (co != null)
            {
                return View(co);
            }
            return HttpNotFound();
        }

        // POST: CO/Edit/5
        [HttpPost]
        public ActionResult COEdit(CadastralObject co)
        {
            db.Entry(co).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListCO");
        }

        // GET: CO/Delete/5
        [HttpGet]
        public ActionResult CODelete(int id)
        {
            CadastralObject co = db.CadastralObjects.Find(id);
            if (co == null)
            {
                return HttpNotFound();
            }
            return View(co);
        }

        // POST: CO/Delete/5
        [HttpPost, ActionName("CODelete")]
        public ActionResult CODeleteConfirmed(int id)
        {
            CadastralObject co = db.CadastralObjects.Find(id);
            if (co == null)
            {
                return HttpNotFound();
            }
            db.CadastralObjects.Remove(co);
            db.SaveChanges();
            return RedirectToAction("ListCO");
        }
    }
}
