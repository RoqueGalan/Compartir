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
    public class PiezaController : Controller
    {
        private MuseoContext db = new MuseoContext();

        // GET: Pieza
        public ActionResult Index()
        {
            var piezas = db.Piezas.Include(p => p.Obra).Include(p => p.TipoPieza);
            return View(piezas.ToList());
        }

        // GET: Pieza/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pieza pieza = db.Piezas.Find(id);
            if (pieza == null)
            {
                return HttpNotFound();
            }
            return View(pieza);
        }

        // GET: Pieza/Create
        public ActionResult Create()
        {
            ViewBag.ObraID = new SelectList(db.Obras, "ObraID", "Titulo");
            ViewBag.TipoPiezaID = new SelectList(db.TiposPiezas, "TipoPiezaID", "Nombre");
            return View();
        }

        // POST: Pieza/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PiezaID,ObraID,TipoPiezaID,Matricula,MatriculaTecnica")] Pieza pieza)
        {
            if (ModelState.IsValid)
            {
                db.Piezas.Add(pieza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObraID = new SelectList(db.Obras, "ObraID", "Titulo", pieza.ObraID);
            ViewBag.TipoPiezaID = new SelectList(db.TiposPiezas, "TipoPiezaID", "Nombre", pieza.TipoPiezaID);
            return View(pieza);
        }

        // GET: Pieza/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pieza pieza = db.Piezas.Find(id);
            if (pieza == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObraID = new SelectList(db.Obras, "ObraID", "Titulo", pieza.ObraID);
            ViewBag.TipoPiezaID = new SelectList(db.TiposPiezas, "TipoPiezaID", "Nombre", pieza.TipoPiezaID);
            return View(pieza);
        }

        // POST: Pieza/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PiezaID,ObraID,TipoPiezaID,Matricula,MatriculaTecnica")] Pieza pieza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pieza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObraID = new SelectList(db.Obras, "ObraID", "Titulo", pieza.ObraID);
            ViewBag.TipoPiezaID = new SelectList(db.TiposPiezas, "TipoPiezaID", "Nombre", pieza.TipoPiezaID);
            return View(pieza);
        }

        // GET: Pieza/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pieza pieza = db.Piezas.Find(id);
            if (pieza == null)
            {
                return HttpNotFound();
            }
            return View(pieza);
        }

        // POST: Pieza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pieza pieza = db.Piezas.Find(id);
            db.Piezas.Remove(pieza);
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
