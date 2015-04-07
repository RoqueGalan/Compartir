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
    public class TipoObraController : Controller
    {
        private MuseoContext db = new MuseoContext();

        // GET: TipoObra
        public ActionResult Index()
        {
            return View(db.TiposObras.ToList());
        }

        // GET: TipoObra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoObra tipoObra = db.TiposObras.Find(id);
            if (tipoObra == null)
            {
                return HttpNotFound();
            }
            return View(tipoObra);
        }

        // GET: TipoObra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoObra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoObraID,Nombre,Estado")] TipoObra tipoObra)
        {
            if (ModelState.IsValid)
            {
                db.TiposObras.Add(tipoObra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoObra);
        }

        // GET: TipoObra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoObra tipoObra = db.TiposObras.Find(id);
            if (tipoObra == null)
            {
                return HttpNotFound();
            }
            return View(tipoObra);
        }

        // POST: TipoObra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoObraID,Nombre,Estado")] TipoObra tipoObra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoObra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoObra);
        }

        // GET: TipoObra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoObra tipoObra = db.TiposObras.Find(id);
            if (tipoObra == null)
            {
                return HttpNotFound();
            }
            return View(tipoObra);
        }

        // POST: TipoObra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoObra tipoObra = db.TiposObras.Find(id);
            db.TiposObras.Remove(tipoObra);
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
