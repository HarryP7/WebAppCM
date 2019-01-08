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
        //private DAOCadastralObject dao = new DAOCadastralObject();
        // GET: CO
        public ActionResult ListCO()
        {
            //var items = db.CadastralObjects;
            //dao.GetAllCO();
            var items = db.CadastralObjects.Include(p => p.HandBookOfCOType);
            return View(items.ToList());
        }
        // GET: CO/Details/5
        public ActionResult typeCODetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            HandBookOfCOType typeCO = db.typeCOs.Find(id);
            if (typeCO == null)
            {
                return HttpNotFound();
            }
            typeCO.co = db.CadastralObjects.Where(m => m.fk_tipeCO == typeCO.Id);
            return View(typeCO);
        }

        // GET: CO/Create
       // [Authorize(Roles = "Admin, Engineer")]
        public ActionResult COCreate()
        {
            // Формируем список типов КО для передачи в представление
            SelectList type = new SelectList(db.typeCOs, "Id", "tHCOname");
            ViewBag.TipeCO = type;
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
        [HttpGet/*, Authorize(Roles = "Admin, Engineer")*/]
        public ActionResult COEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            // Находим в бд футболиста
            CadastralObject co = db.CadastralObjects.Find(id);
            if (co != null)
            {
                // Создаем список команд для передачи в представление
                SelectList teams = new SelectList(db.typeCOs, "Id", "Name", co.fk_tipeCO);
                ViewBag.Teams = teams;
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
        [HttpGet/*, Authorize(Roles = "Admin, Engineer")*/]
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
