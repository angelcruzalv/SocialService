using cecati_117.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cecati_117.Controllers
{
    public class Escoge_EspecialidadController : Controller
    {
        private Contexto_BaseDatos db = new Contexto_BaseDatos();

        // GET: Escoge_Especialidad
        public ActionResult Index()
        {
            var list = db.EspecialidadDetalles.OrderBy(x => Guid.NewGuid()).ToList();
            return View(list);
        }
    }
}