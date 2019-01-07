using System;
using System.Collections.Generic;
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

        // GET: CO/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CO/Edit/5
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

        // GET: CO/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CO/Delete/5
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
