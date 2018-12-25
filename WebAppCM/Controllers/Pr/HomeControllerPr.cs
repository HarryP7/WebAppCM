using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppCM.Controllers 
{
    public class HomeControllerPr : Controller
    {
        public ActionResult IndexPr()
        {
            return View();
        }

        public ActionResult AboutPr()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ContactPr()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}