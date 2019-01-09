using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCM.Models;

namespace WebAppCM.Controllers.COTypeController
{
    public class COTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: COType        
        public ActionResult ShowHandBookOfCOType()
        {
            var items = db.HandBookOfCOTypes;
            return View(items.ToList());
        }
        // GET: COType/Details/5
        public ActionResult typeCODetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            HandBookOfCOType typeCO = db.HandBookOfCOTypes.Find(id);
            if (typeCO == null)
            {
                return HttpNotFound();
            }
            typeCO.co = db.CadastralObjects.Where(m => m.fk_typeCO == typeCO.Id);
            return View(typeCO);
        }

        // GET: COType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: COType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: COType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: COType/Edit/5
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

        // GET: COType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: COType/Delete/5
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
