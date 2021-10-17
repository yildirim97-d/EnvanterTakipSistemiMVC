using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sirket.Models.Entity;

namespace sirket.Controllers
{
    public class cihazController : Controller
    {
        SirketZT ci =  new SirketZT();
       
        // GET: cihaz
        public ActionResult Index()
        {
            var degerler = ci.cihaz.ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult CihazEkle()
        {

            //ViewBag.Kullanicilar = new SelectList(ci.kullanici, "kullanici_id", "kullanici_adi");
            //List<kullanici> users = ci.kullanici.ToList();
            // ViewBag.Users = users;
            var marka_kategori_model = ci.marka_kategori.ToList();

            return View(marka_kategori_model);
        }
        [HttpPost]
        public ActionResult CihazEkle(cihaz c1)
        {
            ci.cihaz.Add(c1);
            ci.SaveChanges();
           
            return RedirectToAction("Index", "cihaz");

        }
        public ActionResult SİL(int id)
        {
            var cihaz = ci.cihaz.Find(id);
            ci.cihaz.Remove(cihaz);
            ci.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Guncelle(int id)
        {

            var query1 = ci.cihaz.Where(c => c.cihaz_id == id).FirstOrDefault();
            var markaId = query1.marka_id;

            ViewBag.Marka_Kategori = new SelectList(ci.marka_kategori.ToList(), "marka_id", "marka_ad", markaId);
            //ViewBag.Marka_Kategori = ci.marka_kategori.ToList();
            //ViewBag.MarkaId = query1.marka_id;
            
            return View(query1);
        }


        [HttpPost]
        public ActionResult Guncelle(cihaz c1)
        {
            var query1 = ci.cihaz.Where(c => c.cihaz_id == c1.cihaz_id).FirstOrDefault();
            query1.cihaz_ad = c1.cihaz_ad;
            query1.cihaz_tür = c1.cihaz_tür;
            query1.marka_id = c1.marka_id;
            query1.cihaz_konum = c1.cihaz_konum;
            query1.cihaz_durum = c1.cihaz_durum;
            query1.cihaz_zimmet_tarih = c1.cihaz_zimmet_tarih;
            //query1.kullanici_id = c1.kullanici_id;
            ci.Entry(query1).State = EntityState.Modified;
            ci.SaveChanges();
            return RedirectToAction("Index");
        }



    }
    
    }

    
