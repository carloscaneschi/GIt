using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrabalhoWebII.Models;

namespace TrabalhoWebII.Controllers
{
    public class SpcserasasController : Controller
    {
        private ContestDados db = new ContestDados();

        // GET: Spcserasas
        public ActionResult Index()
        {
            return View(db.Spcserasas.ToList());
        }

        // GET: Spcserasas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spcserasa spcserasa = db.Spcserasas.Find(id);
            if (spcserasa == null)
            {
                return HttpNotFound();
            }
            return View(spcserasa);
        }

        // GET: Spcserasas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spcserasas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idprotesto,data")] Spcserasa spcserasa)
        {
            if (ModelState.IsValid)
            {
                db.Spcserasas.Add(spcserasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spcserasa);
        }

        // GET: Spcserasas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spcserasa spcserasa = db.Spcserasas.Find(id);
            if (spcserasa == null)
            {
                return HttpNotFound();
            }
            return View(spcserasa);
        }

        // POST: Spcserasas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idprotesto,data")] Spcserasa spcserasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spcserasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spcserasa);
        }

        // GET: Spcserasas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spcserasa spcserasa = db.Spcserasas.Find(id);
            if (spcserasa == null)
            {
                return HttpNotFound();
            }
            return View(spcserasa);
        }

        // POST: Spcserasas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spcserasa spcserasa = db.Spcserasas.Find(id);
            db.Spcserasas.Remove(spcserasa);
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
