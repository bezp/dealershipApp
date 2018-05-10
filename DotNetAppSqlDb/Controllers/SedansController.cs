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
    public class SedansController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Sedans
        public ActionResult Index(string searchString)
        {
            var Sedans = from m in db.Sedans
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Sedans = Sedans.Where(s => s.Model.Contains(searchString));
            }

            return View(Sedans);
        }

        // GET: Sedans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sedan sedan = db.Sedans.Find(id);
            if (sedan == null)
            {
                return HttpNotFound();
            }
            return View(sedan);
        }

        // GET: Sedans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sedans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Model,MSRP,Horsepower,MPG")] Sedan sedan)
        {
            if (ModelState.IsValid)
            {
                db.Sedans.Add(sedan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sedan);
        }

        // GET: Sedans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sedan sedan = db.Sedans.Find(id);
            if (sedan == null)
            {
                return HttpNotFound();
            }
            return View(sedan);
        }

        // POST: Sedans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Model,MSRP,Horsepower,MPG")] Sedan sedan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sedan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sedan);
        }

        // GET: Sedans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sedan sedan = db.Sedans.Find(id);
            if (sedan == null)
            {
                return HttpNotFound();
            }
            return View(sedan);
        }

        // POST: Sedans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sedan sedan = db.Sedans.Find(id);
            db.Sedans.Remove(sedan);
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
