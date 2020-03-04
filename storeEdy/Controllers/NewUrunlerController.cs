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

namespace storeEdy.Controllers
{
    public class NewUrunlerController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            return View(db.Urunler.ToList());
        }


        [HttpPost]
        public ActionResult Satis(string barkod, NewUrunler urun)
        {
            var urunler = db.Urunler.ToList().Where(p => p.barkod.StartsWith(barkod));
            return View(urunler);
        }

        public ActionResult Satis()
        {
            return View(db.Urunler.ToList());
        }

        // GET: NewUrunler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUrunler newUrunler = db.Urunler.Find(id);
            if (newUrunler == null)
            {
                return HttpNotFound();
            }
            return View(newUrunler);
        }

        // GET: NewUrunler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewUrunler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "urunid,barkod,urunAd,urunAciklama,urunFiyat")] NewUrunler newUrunler)
        {
            if (ModelState.IsValid)
            {
                db.Urunler.Add(newUrunler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newUrunler);
        }

        // GET: NewUrunler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUrunler newUrunler = db.Urunler.Find(id);
            if (newUrunler == null)
            {
                return HttpNotFound();
            }
            return View(newUrunler);
        }

        // POST: NewUrunler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "urunid,barkod,urunAd,urunAciklama,urunFiyat")] NewUrunler newUrunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newUrunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newUrunler);
        }

        // GET: NewUrunler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewUrunler newUrunler = db.Urunler.Find(id);
            if (newUrunler == null)
            {
                return HttpNotFound();
            }
            return View(newUrunler);
        }

        // POST: NewUrunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewUrunler newUrunler = db.Urunler.Find(id);
            db.Urunler.Remove(newUrunler);
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
