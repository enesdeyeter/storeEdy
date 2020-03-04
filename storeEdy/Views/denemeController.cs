using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using storeEdy.Manager;
using storeEdy.Models;

namespace storeEdy.Views
{
    public class denemeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: deneme
        public ActionResult Index()
        {
            var fisler = db.Fisler.Include(n => n.SepetOturum);
            return View(fisler.ToList());
        }

        // GET: deneme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewFisler newFisler = db.Fisler.Find(id);
            if (newFisler == null)
            {
                return HttpNotFound();
            }
            return View(newFisler);
        }

        // GET: deneme/Create
        public ActionResult Create()
        {
            ViewBag.sepetoturumid = new SelectList(db.SepetOturumlar, "sepetoturumid", "sepetoturumid");
            return View();
        }

        // POST: deneme/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fisid,fisTutar,tarih,sepetoturumid")] NewFisler newFisler)
        {
            if (ModelState.IsValid)
            {
                db.Fisler.Add(newFisler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sepetoturumid = new SelectList(db.SepetOturumlar, "sepetoturumid", "sepetoturumid", newFisler.sepetoturumid);
            return View(newFisler);
        }

        // GET: deneme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewFisler newFisler = db.Fisler.Find(id);
            if (newFisler == null)
            {
                return HttpNotFound();
            }
            ViewBag.sepetoturumid = new SelectList(db.SepetOturumlar, "sepetoturumid", "sepetoturumid", newFisler.sepetoturumid);
            return View(newFisler);
        }

        // POST: deneme/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fisid,fisTutar,tarih,sepetoturumid")] NewFisler newFisler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newFisler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sepetoturumid = new SelectList(db.SepetOturumlar, "sepetoturumid", "sepetoturumid", newFisler.sepetoturumid);
            return View(newFisler);
        }

        // GET: deneme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewFisler newFisler = db.Fisler.Find(id);
            if (newFisler == null)
            {
                return HttpNotFound();
            }
            return View(newFisler);
        }

        // POST: deneme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewFisler newFisler = db.Fisler.Find(id);
            db.Fisler.Remove(newFisler);
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
