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
    public class TipoPermisoController : Controller
    {
        private MuseoContext db = new MuseoContext();

        // GET: TipoPermiso
        public ActionResult Index()
        {
            return View(db.TiposPermisos.ToList());
        }

        // GET: TipoPermiso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPermiso tipoPermiso = db.TiposPermisos.Find(id);
            if (tipoPermiso == null)
            {
                return HttpNotFound();
            }
            return View(tipoPermiso);
        }

        // GET: TipoPermiso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPermiso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoPermisoID,Nombre,Codigo,Estado")] TipoPermiso tipoPermiso)
        {
            if (ModelState.IsValid)
            {
                db.TiposPermisos.Add(tipoPermiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPermiso);
        }

        // GET: TipoPermiso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPermiso tipoPermiso = db.TiposPermisos.Find(id);
            if (tipoPermiso == null)
            {
                return HttpNotFound();
            }
            return View(tipoPermiso);
        }

        // POST: TipoPermiso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoPermisoID,Nombre,Codigo,Estado")] TipoPermiso tipoPermiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPermiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPermiso);
        }

        // GET: TipoPermiso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPermiso tipoPermiso = db.TiposPermisos.Find(id);
            if (tipoPermiso == null)
            {
                return HttpNotFound();
            }
            return View(tipoPermiso);
        }

        // POST: TipoPermiso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPermiso tipoPermiso = db.TiposPermisos.Find(id);
            db.TiposPermisos.Remove(tipoPermiso);
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
