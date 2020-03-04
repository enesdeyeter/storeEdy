using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using storeEdy.Manager;
using storeEdy.Models;

namespace storeEdy.Controllers
{
    public class SatisController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        // GET: Satis
        public ActionResult Index()
        {
            var sepetoturum = db.SepetOturumlar.FirstOrDefault(x => x.durum == 0);
            if (sepetoturum == null)
            {
                sepetoturum = new SepetOturum
                {   
                    durum = 0,
                    tarih = DateTime.Now
                    
                };
                db.SepetOturumlar.Add(sepetoturum);
                db.SaveChanges();
              
            }
            if (sepetoturum.Sepets==null)
            {
                return RedirectToAction("Index");
            }
            return View(sepetoturum);
        }

        public ActionResult Fisler()
        {
            var fis = db.Fisler.ToList();
            fis.Reverse();
            return View(fis);
        }


        public PartialViewResult FisAyrinti(int id)
        {
            return PartialView(db.Fisler.FirstOrDefault(x=>x.fisid==id));
        }
      

        public ActionResult Delete(int? id)
        {
            Sepet sepet = db.Sepetler.FirstOrDefault(x => x.sepetid == id);
            if (sepet!=null)
            {
                db.Sepetler.Remove(sepet);
            }
            
         
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Sepet()
        //{
        //    return View();
        //}


        // GET: NewUrunler/Details/5
        public ActionResult Sepet(int? id)

        {
            var sepetoturum = db.SepetOturumlar.FirstOrDefault(x => x.durum == 0);
            if (sepetoturum==null)
            {
                sepetoturum = new SepetOturum
                {
                    durum=0,
                    tarih=DateTime.Now
                };
                db.SepetOturumlar.Add(sepetoturum);
                db.SaveChanges();
            }
            sepetoturum.Sepets.Add(new Models.Sepet { durum=1, urunid=id.Value,sepetoturumid=sepetoturum.sepetoturumid});
            db.SaveChanges();
          
            return RedirectToAction("Index");


          /*  if (Session["sepet"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.Urunler.Find(id), 1));
                Session["sepet"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["sepet"];
                int index = isExisting(id);
                if (index == -1)
                    cart.Add(new Item(db.Urunler.Find(id), 1));
                else
                    cart[index].Quantity++;
                Session["sepet"] = cart; 
                
            }
            return View("Sepet");*/
        }
        public ActionResult Ode(int id)
        {
            var sonsepet = db.SepetOturumlar.FirstOrDefault(x => x.durum == 0 && x.sepetoturumid==id);
            sonsepet.durum = 1;
            NewFisler fis = new NewFisler
            {
                sepetoturumid = sonsepet.sepetoturumid,
                fisTutar = sonsepet.Sepets.Sum(x => x.NewUrunler.urunFiyat),
                
                tarih = DateTime.Now
            };
            db.Fisler.Add(fis);
            db.SaveChanges();
            return RedirectToAction("Fisler");
        }


    }
}