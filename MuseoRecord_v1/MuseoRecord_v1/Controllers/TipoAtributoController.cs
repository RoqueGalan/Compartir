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
    public class TipoAtributoController : Controller
    {
        private MuseoContext db = new MuseoContext();

        // GET: TipoAtributo
        public ActionResult Index()
        {
            return View(db.TiposAtributos.ToList());
        }

        // GET: TipoAtributo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAtributo tipoAtributo = db.TiposAtributos.Find(id);
            if (tipoAtributo == null)
            {
                return HttpNotFound();
            }
            return View(tipoAtributo);
        }

        // GET: TipoAtributo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAtributo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoAtributoID,Nombre,EsLista,Estado")] TipoAtributo tipoAtributo)
        {
            if (ModelState.IsValid)
            {
                db.TiposAtributos.Add(tipoAtributo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAtributo);
        }

        // GET: TipoAtributo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAtributo tipoAtributo = db.TiposAtributos.Find(id);
            if (tipoAtributo == null)
            {
                return HttpNotFound();
            }
            return View(tipoAtributo);
        }

        // POST: TipoAtributo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoAtributoID,Nombre,EsLista,Estado")] TipoAtributo tipoAtributo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAtributo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAtributo);
        }

        // GET: TipoAtributo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAtributo tipoAtributo = db.TiposAtributos.Find(id);
            if (tipoAtributo == null)
            {
                return HttpNotFound();
            }
            return View(tipoAtributo);
        }

        // POST: TipoAtributo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAtributo tipoAtributo = db.TiposAtributos.Find(id);
            db.TiposAtributos.Remove(tipoAtributo);
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
