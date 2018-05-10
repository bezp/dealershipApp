using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Models;

namespace DotNetAppSqlDb.Controllers
{
    public class CrossoversController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Crossovers
        public ActionResult Index(string searchString)
        {
            var Crossovers = from m in db.Crossovers
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Crossovers = Crossovers.Where(s => s.Model.Contains(searchString));
            }

            return View(Crossovers);
        }

        // GET: Crossovers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crossover crossover = db.Crossovers.Find(id);
            if (crossover == null)
            {
                return HttpNotFound();
            }
            return View(crossover);
        }

        // GET: Crossovers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crossovers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Model,MSRP,Horsepower,MPG")] Crossover crossover)
        {
            if (ModelState.IsValid)
            {
                db.Crossovers.Add(crossover);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crossover);
        }

        // GET: Crossovers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crossover crossover = db.Crossovers.Find(id);
            if (crossover == null)
            {
                return HttpNotFound();
            }
            return View(crossover);
        }

        // POST: Crossovers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Model,MSRP,Horsepower,MPG")] Crossover crossover)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crossover).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crossover);
        }

        // GET: Crossovers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crossover crossover = db.Crossovers.Find(id);
            if (crossover == null)
            {
                return HttpNotFound();
            }
            return View(crossover);
        }

        // POST: Crossovers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crossover crossover = db.Crossovers.Find(id);
            db.Crossovers.Remove(crossover);
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
