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
    public class TipoAdquisicionController : Controller
    {
        private MuseoContext db = new MuseoContext();

        // GET: TipoAdquisicion
        public ActionResult Index()
        {
            return View(db.TiposAdquisiciones.ToList());
        }

        // GET: TipoAdquisicion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAdquisicion tipoAdquisicion = db.TiposAdquisiciones.Find(id);
            if (tipoAdquisicion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAdquisicion);
        }

        // GET: TipoAdquisicion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAdquisicion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoAdquisicionID,Nombre,Estado")] TipoAdquisicion tipoAdquisicion)
        {
            if (ModelState.IsValid)
            {
                db.TiposAdquisiciones.Add(tipoAdquisicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAdquisicion);
        }

        // GET: TipoAdquisicion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAdquisicion tipoAdquisicion = db.TiposAdquisiciones.Find(id);
            if (tipoAdquisicion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAdquisicion);
        }

        // POST: TipoAdquisicion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoAdquisicionID,Nombre,Estado")] TipoAdquisicion tipoAdquisicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAdquisicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAdquisicion);
        }

        // GET: TipoAdquisicion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAdquisicion tipoAdquisicion = db.TiposAdquisiciones.Find(id);
            if (tipoAdquisicion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAdquisicion);
        }

        // POST: TipoAdquisicion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAdquisicion tipoAdquisicion = db.TiposAdquisiciones.Find(id);
            db.TiposAdquisiciones.Remove(tipoAdquisicion);
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
