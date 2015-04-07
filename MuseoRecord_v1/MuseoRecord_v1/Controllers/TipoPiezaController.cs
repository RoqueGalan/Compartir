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
    public class TipoPiezaController : Controller
    {
        private MuseoContext db = new MuseoContext();

        // GET: TipoPieza
        public ActionResult Index()
        {
            var tiposPiezas = db.TiposPiezas.Include(t => t.TipoObra);
            return View(tiposPiezas.ToList());
        }

        // GET: TipoPieza/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPieza tipoPieza = db.TiposPiezas.Find(id);
            if (tipoPieza == null)
            {
                return HttpNotFound();
            }
            return View(tipoPieza);
        }

        // GET: TipoPieza/Create
        public ActionResult Create()
        {
            ViewBag.TipoObraID = new SelectList(db.TiposObras, "TipoObraID", "Nombre");
            return View();
        }

        // POST: TipoPieza/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoPiezaID,TipoObraID,Nombre,Estado")] TipoPieza tipoPieza)
        {
            if (ModelState.IsValid)
            {
                db.TiposPiezas.Add(tipoPieza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoObraID = new SelectList(db.TiposObras, "TipoObraID", "Nombre", tipoPieza.TipoObraID);
            return View(tipoPieza);
        }

        // GET: TipoPieza/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPieza tipoPieza = db.TiposPiezas.Find(id);
            if (tipoPieza == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoObraID = new SelectList(db.TiposObras, "TipoObraID", "Nombre", tipoPieza.TipoObraID);
            return View(tipoPieza);
        }

        // POST: TipoPieza/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoPiezaID,TipoObraID,Nombre,Estado")] TipoPieza tipoPieza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPieza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoObraID = new SelectList(db.TiposObras, "TipoObraID", "Nombre", tipoPieza.TipoObraID);
            return View(tipoPieza);
        }

        // GET: TipoPieza/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPieza tipoPieza = db.TiposPiezas.Find(id);
            if (tipoPieza == null)
            {
                return HttpNotFound();
            }
            return View(tipoPieza);
        }

        // POST: TipoPieza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPieza tipoPieza = db.TiposPiezas.Find(id);
            db.TiposPiezas.Remove(tipoPieza);
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
