using cecati_117.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cecati_117.Controllers
{
    public class WorkController : Controller
    {
        private Contexto_BaseDatos db = new Contexto_BaseDatos();
        // GET: Work
        public ActionResult Index()
        {
            return View(db.BolsaDeTrabajo.ToList());
        }
    }
}