using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logistica.Controllers
{
    public class RastreioController : Controller
    {
        // GET: Rastreio
        public ActionResult Rastreio()
        {
            ViewBag.Message = "Rastreio";
            return View();
        }

        public ActionResult RastreioItem()
        {
            ViewBag.Message = "RastreioItem";
            return View();
        }
    }
}