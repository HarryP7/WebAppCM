﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppCM.Models;

namespace WebAppCM.Controllers.COController
{
    public class COController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CO
        [HttpGet, Authorize(Roles = "Admin, Engineer,Castomer")]
        public ActionResult ListCO()
        {
            var items = db.CadastralObjects.Include(p => p.HandBookOfCOType);
            return View(items.ToList());
        }
        // GET: CO/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: CO/Create
        [HttpGet, Authorize(Roles = "Admin, Engineer")]       
        public ActionResult COCreate()
        {
            // Формируем список типов КО для передачи в представление
            SelectList type = new SelectList(db.HandBookOfCOTypes, "Id", "tHCOname");
            ViewBag.HandBookOfCOTypes = type;
            return View();
        }

        // POST: CO/Create
        [HttpPost]
        public ActionResult COCreate(CadastralObject co)
        {
            //Добавляем КО в таблицу
            db.CadastralObjects.Add(co);
            db.SaveChanges();
            return RedirectToAction("ListCO");
        }

        // GET: CO/Edit/5
        [HttpGet, Authorize(Roles = "Admin, Engineer")]
        public ActionResult COEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            // Находим в бд выбранный KO
            CadastralObject co = db.CadastralObjects.Find(id);
            if (co != null)
            {
                // Создаем список типо КО для передачи в представление
                SelectList type = new SelectList(db.HandBookOfCOTypes, "Id", "tHCOname", co.fk_typeCO);
                ViewBag.HandBookOfCOTypes = type;
                return View(co);
            }
            return RedirectToAction("ListCO");            
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
        [HttpGet, Authorize(Roles = "Admin, Engineer")]
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
