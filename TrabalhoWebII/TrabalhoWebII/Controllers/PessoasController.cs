﻿using System;
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
    public class PessoasController : Controller
    {
        private ContestDados db = new ContestDados();

        // GET: Pessoas
        public ActionResult Index()
        {
            var pessoas = db.Pessoas.Include(p => p.Spcserasa);
            return View(pessoas.ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            ViewBag.Idprotesto = new SelectList(db.Spcserasas, "Idprotesto", "Idprotesto");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDpessoa,Cpf,Rg,Fone,Nome,UF,Cidade,Endereco,Bairro,Idprotesto")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Idprotesto = new SelectList(db.Spcserasas, "Idprotesto", "Idprotesto", pessoa.Idprotesto);
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Idprotesto = new SelectList(db.Spcserasas, "Idprotesto", "Idprotesto", pessoa.Idprotesto);
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDpessoa,Cpf,Rg,Fone,Nome,UF,Cidade,Endereco,Bairro,Idprotesto")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Idprotesto = new SelectList(db.Spcserasas, "Idprotesto", "Idprotesto", pessoa.Idprotesto);
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
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
