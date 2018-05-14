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
    public class CompactsController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();


        // GET: Compacts
        //public ActionResult Index()
        //{
        //    return View(db.Compacts.ToList());
        //}

        public ActionResult Index(string searchString, string sortOrder)
        {
            ViewBag.ModelSortParm = String.IsNullOrEmpty(sortOrder) ? "Model_desc" : "";
            ViewBag.MSRPSortParm = sortOrder == "MSRP" ? "MSRP_desc" : "MSRP";
            ViewBag.HorsepowerSortParm = sortOrder == "Horsepower" ? "Horsepower_desc" : "Horsepower";
            var Compacts = from m in db.Compacts
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Compacts = Compacts.Where(s => s.Model.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Model_desc":
                    Compacts = Compacts.OrderByDescending(s => s.Model);
                    break;
                case "MSRP":
                    Compacts = Compacts.OrderBy(s => s.MSRP);
                    break;
                case "MSRP_desc":
                    Compacts = Compacts.OrderByDescending(s => s.MSRP);
                    break;
                case "Horsepower":
                    Compacts = Compacts.OrderBy(s => s.Horsepower);
                    break;
                case "Horsepower_desc":
                    Compacts = Compacts.OrderByDescending(s => s.Horsepower);
                    break;
                default:
                    Compacts = Compacts.OrderBy(s => s.Model);
                    break;
            }

            return View(Compacts);
        }


        // GET: Compacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compact compact = db.Compacts.Find(id);
            if (compact == null)
            {
                return HttpNotFound();
            }
            return View(compact);
        }

        // GET: Compacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Model,MSRP,Horsepower,MPG")] Compact compact)
        {
            if (ModelState.IsValid)
            {
                db.Compacts.Add(compact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compact);
        }

        // GET: Compacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compact compact = db.Compacts.Find(id);
            if (compact == null)
            {
                return HttpNotFound();
            }
            return View(compact);
        }

        // POST: Compacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Model,MSRP,Horsepower,MPG")] Compact compact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compact);
        }

        // GET: Compacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compact compact = db.Compacts.Find(id);
            if (compact == null)
            {
                return HttpNotFound();
            }
            return View(compact);
        }

        // POST: Compacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compact compact = db.Compacts.Find(id);
            db.Compacts.Remove(compact);
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
