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
    public class AtributoController : Controller
    {
        private MuseoContext db = new MuseoContext();

        // GET: Atributo
        public ActionResult Index()
        {
            var atributos = db.Atributos.Include(a => a.Estructura).Include(a => a.Lista).Include(a => a.Pieza);
            return View(atributos.ToList());
        }

        // GET: Atributo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atributo atributo = db.Atributos.Find(id);
            if (atributo == null)
            {
                return HttpNotFound();
            }
            return View(atributo);
        }

        // GET: Atributo/Create
        public ActionResult Create()
        {
            ViewBag.EstructuraID = new SelectList(db.Estructuras, "EstructuraID", "EstructuraID");

            ViewBag.ListaID = new SelectList(db.Listas, "ListaID", "Valor");
            ViewBag.PiezaID = new SelectList(db.Piezas, "PiezaID", "Matricula");
            return View();
        }

        // POST: Atributo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PiezaID,EstructuraID,Valor,ListaID")] Atributo atributo)
        {
            if (ModelState.IsValid)
            {
                db.Atributos.Add(atributo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstructuraID = new SelectList(db.Estructuras, "EstructuraID", "EstructuraID", atributo.EstructuraID);
            ViewBag.ListaID = new SelectList(db.Listas, "ListaID", "Valor", atributo.ListaID);
            ViewBag.PiezaID = new SelectList(db.Piezas, "PiezaID", "Matricula", atributo.PiezaID);
            return View(atributo);
        }

        // GET: Atributo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atributo atributo = db.Atributos.Find(id);
            if (atributo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstructuraID = new SelectList(db.Estructuras, "EstructuraID", "EstructuraID", atributo.EstructuraID);
            ViewBag.ListaID = new SelectList(db.Listas, "ListaID", "Valor", atributo.ListaID);
            ViewBag.PiezaID = new SelectList(db.Piezas, "PiezaID", "Matricula", atributo.PiezaID);
            return View(atributo);
        }

        // POST: Atributo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PiezaID,EstructuraID,Valor,ListaID")] Atributo atributo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atributo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstructuraID = new SelectList(db.Estructuras, "EstructuraID", "EstructuraID", atributo.EstructuraID);
            ViewBag.ListaID = new SelectList(db.Listas, "ListaID", "Valor", atributo.ListaID);
            ViewBag.PiezaID = new SelectList(db.Piezas, "PiezaID", "Matricula", atributo.PiezaID);
            return View(atributo);
        }

        // GET: Atributo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atributo atributo = db.Atributos.Find(id);
            if (atributo == null)
            {
                return HttpNotFound();
            }
            return View(atributo);
        }

        // POST: Atributo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atributo atributo = db.Atributos.Find(id);
            db.Atributos.Remove(atributo);
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
