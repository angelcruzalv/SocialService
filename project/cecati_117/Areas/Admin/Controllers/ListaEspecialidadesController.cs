using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cecati_117.Areas.Admin.ClasesCompartidas;
using cecati_117.Context;
using cecati_117.Models;

namespace cecati_117.Areas.Admin.Controllers
{
    [Authorize]
    public class ListaEspecialidadesController : Controller
    {
        private Contexto_BaseDatos db = new Contexto_BaseDatos();
        private FuncionesUtilesController funcionesUtiles = new FuncionesUtilesController();
        // GET: Admin/ListaEspecialidades
        public ActionResult Index()
        {

            return View(db.ListaEspecialidades.ToList());
        }

        // GET: Admin/ListaEspecialidades/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaEspecialidades listaEspecialidades = db.ListaEspecialidades.Find(id);
            if (listaEspecialidades == null)
            {
                return HttpNotFound();
            }
            return View(listaEspecialidades);
        }

        // GET: Admin/ListaEspecialidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ListaEspecialidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListaEspecialidades_ID,ListaEspecialidades_especialidad")] ListaEspecialidades listaEspecialidades)
        {
            if (ModelState.IsValid)
            {
                listaEspecialidades.ListaEspecialidades_ID = Guid.NewGuid();
                db.ListaEspecialidades.Add(listaEspecialidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listaEspecialidades);
        }

        // GET: Admin/ListaEspecialidades/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaEspecialidades listaEspecialidades = db.ListaEspecialidades.Find(id);
            if (listaEspecialidades == null)
            {
                return HttpNotFound();
            }
            return View(listaEspecialidades);
        }

        // POST: Admin/ListaEspecialidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListaEspecialidades_ID,ListaEspecialidades_especialidad")] ListaEspecialidades listaEspecialidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaEspecialidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listaEspecialidades);
        }

        // GET: Admin/ListaEspecialidades/Delete/5
        // POST: Admin/ListaEspecialidades/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaEspecialidades listaEspecialidades = db.ListaEspecialidades.Find(id);
            if (listaEspecialidades == null)
            {
                return HttpNotFound();
            }
            var lista = listaEspecialidades.EspecialidadDetalles.ToList();
            foreach(var pagina in lista)
            {
                funcionesUtiles.QuitarImagen_Servidor(pagina.EspecialidadDetalles_Imagen, this.Server);
                db.EspecialidadDetalles.Remove(pagina);
            }
            db.ListaEspecialidades.Remove(listaEspecialidades);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
