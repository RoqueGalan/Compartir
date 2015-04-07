using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MuseoRecord_v1.Models;

namespace MuseoRecord_v1.Controllers
{
    public class EstructuraController : Controller
    {
        private MuseoContext db = new MuseoContext();

        // GET: Estructura
        public ActionResult Index()
        {
            var estructuras = db.Estructuras.Include(e => e.TipoAtributo).Include(e => e.TipoPieza);
            return View(estructuras.ToList());
        }

        // GET: Estructura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estructura estructura = db.Estructuras.Find(id);
            if (estructura == null)
            {
                return HttpNotFound();
            }
            return View(estructura);
        }

        // GET: Estructura/Create
        public ActionResult Create()
        {
            ViewBag.TipoAtributoID = new SelectList(db.TiposAtributos, "TipoAtributoID", "Nombre");
            ViewBag.TipoPiezaID = new SelectList(db.TiposPiezas, "TipoPiezaID", "Nombre");
            return View();
        }

        // POST: Estructura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstructuraID,TipoPiezaID,TipoAtributoID,Orden,Estado")] Estructura estructura)
        {
            if (ModelState.IsValid)
            {
                db.Estructuras.Add(estructura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoAtributoID = new SelectList(db.TiposAtributos, "TipoAtributoID", "Nombre", estructura.TipoAtributoID);
            ViewBag.TipoPiezaID = new SelectList(db.TiposPiezas, "TipoPiezaID", "Nombre", estructura.TipoPiezaID);
            return View(estructura);
        }

        // GET: Estructura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estructura estructura = db.Estructuras.Find(id);
            if (estructura == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoAtributoID = new SelectList(db.TiposAtributos, "TipoAtributoID", "Nombre", estructura.TipoAtributoID);
            ViewBag.TipoPiezaID = new SelectList(db.TiposPiezas, "TipoPiezaID", "Nombre", estructura.TipoPiezaID);
            return View(estructura);
        }

        // POST: Estructura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstructuraID,TipoPiezaID,TipoAtributoID,Orden,Estado")] Estructura estructura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estructura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoAtributoID = new SelectList(db.TiposAtributos, "TipoAtributoID", "Nombre", estructura.TipoAtributoID);
            ViewBag.TipoPiezaID = new SelectList(db.TiposPiezas, "TipoPiezaID", "Nombre", estructura.TipoPiezaID);
            return View(estructura);
        }

        // GET: Estructura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estructura estructura = db.Estructuras.Find(id);
            if (estructura == null)
            {
                return HttpNotFound();
            }
            return View(estructura);
        }

        // POST: Estructura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estructura estructura = db.Estructuras.Find(id);
            db.Estructuras.Remove(estructura);
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
