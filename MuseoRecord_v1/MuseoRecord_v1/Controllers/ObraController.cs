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
    public class ObraController : Controller
    {
        private MuseoContext db = new MuseoContext();

        // GET: Obra
        public ActionResult Index()
        {
            var obras = db.Obras.Include(o => o.Propietario).Include(o => o.TipoAdquision).Include(o => o.TipoObra);
            return View(obras.ToList());
        }

        // GET: Obra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obra obra = db.Obras.Find(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            return View(obra);
        }

        // GET: Obra/Create
        public ActionResult Create()
        {
            ViewBag.PropietarioID = new SelectList(db.Propietarios, "PropietarioID", "Nombre");
            ViewBag.TipoAdquisicionID = new SelectList(db.TiposAdquisiciones, "TipoAdquisicionID", "Nombre");
            ViewBag.TipoObraID = new SelectList(db.TiposObras, "TipoObraID", "Nombre");
            return View();
        }

        // POST: Obra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ObraID,Titulo,Matricula,MatriculaTecnica,TipoAdquisicionID,PropietarioID,TipoObraID,Comodato,Estado")] Obra obra)
        {
            if (ModelState.IsValid)
            {
                db.Obras.Add(obra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropietarioID = new SelectList(db.Propietarios, "PropietarioID", "Nombre", obra.PropietarioID);
            ViewBag.TipoAdquisicionID = new SelectList(db.TiposAdquisiciones, "TipoAdquisicionID", "Nombre", obra.TipoAdquisicionID);
            ViewBag.TipoObraID = new SelectList(db.TiposObras, "TipoObraID", "Nombre", obra.TipoObraID);
            return View(obra);
        }

        // GET: Obra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obra obra = db.Obras.Find(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropietarioID = new SelectList(db.Propietarios, "PropietarioID", "Nombre", obra.PropietarioID);
            ViewBag.TipoAdquisicionID = new SelectList(db.TiposAdquisiciones, "TipoAdquisicionID", "Nombre", obra.TipoAdquisicionID);
            ViewBag.TipoObraID = new SelectList(db.TiposObras, "TipoObraID", "Nombre", obra.TipoObraID);
            return View(obra);
        }

        // POST: Obra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ObraID,Titulo,Matricula,MatriculaTecnica,TipoAdquisicionID,PropietarioID,TipoObraID,Comodato,Estado")] Obra obra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropietarioID = new SelectList(db.Propietarios, "PropietarioID", "Nombre", obra.PropietarioID);
            ViewBag.TipoAdquisicionID = new SelectList(db.TiposAdquisiciones, "TipoAdquisicionID", "Nombre", obra.TipoAdquisicionID);
            ViewBag.TipoObraID = new SelectList(db.TiposObras, "TipoObraID", "Nombre", obra.TipoObraID);
            return View(obra);
        }

        // GET: Obra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Obra obra = db.Obras.Find(id);
            if (obra == null)
            {
                return HttpNotFound();
            }
            return View(obra);
        }

        // POST: Obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Obra obra = db.Obras.Find(id);
            db.Obras.Remove(obra);
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
