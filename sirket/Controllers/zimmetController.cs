using sirket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sirket.Controllers
{
    public class zimmetController : Controller
    {
        // GET: zimmet
        SirketZT zb = new SirketZT();
        public ActionResult Index()
        {
            var degerler = zb.zimmet.ToList(); 
            
     
            
            return View(degerler);

        }

        public ActionResult ZimmetEkle()
        {
           
            ViewBag.Cihaz_Isim = new SelectList(zb.cihaz.ToList(), "cihaz_id", "cihaz_ad");
            ViewBag.Tel_Marka = new SelectList(zb.tel_marka.ToList(), "telmarka_id", "telmarka_adi");
            ViewBag.Kullanici_Isim = new SelectList(zb.kullanici.ToList(), "kullanici_id", "kullanici_adi");

            
            return View();
        }

        [HttpPost]
        public ActionResult ZimmetEkle(zimmet z1)
        {
           
           
            try
            {
               
                
                zb.zimmet.Add(z1);
                ViewBag.Cihaz_Isim = new SelectList(zb.cihaz.ToList(), "cihaz_id", "cihaz_ad");
                ViewBag.Tel_Marka = new SelectList(zb.tel_marka.ToList(), "telmarka_id", "telmarka_adi");
                ViewBag.Kullanici_Isim = new SelectList(zb.kullanici.ToList(), "kullanici_id", "kullanici_adi");
                zb.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
               
                return View();
            }
        }

    public ActionResult Edit(int id)
        {


            var query12 = zb.zimmet.Where(x => x.zimmet_id == id).FirstOrDefault();
            var telmarkaId = query12.telmarka_id;
            ViewBag.CihazIsim = new SelectList(zb.cihaz.ToList(), "cihaz_id", "cihaz_ad");
            ViewBag.TelMarkaIsim = new SelectList(zb.tel_marka.ToList(), "telmarka_id", "telmarka_adi");
            ViewBag.KullaniciIsim = new SelectList(zb.kullanici.ToList(), "kullanici_id", "kullanici_adi");
            return View(query12);
        }
        [HttpPost]
        public ActionResult Edit(zimmet x1)
        {
            try
            {
                var query12 = zb.zimmet.Where(x => x.zimmet_id == x1.zimmet_id).FirstOrDefault();
                query12.cihaz_id = x1.cihaz_id;
                query12.kullanici_id = x1.kullanici_id;
                query12.telmarka_id = x1.telmarka_id;
                query12.zimmet_tarih = x1.zimmet_tarih;
                ViewBag.CihazIsim = new SelectList(zb.cihaz.ToList(), "cihaz_id", "cihaz_ad");
                ViewBag.TelMarkaIsim = new SelectList(zb.tel_marka.ToList(), "telmarka_id", "telmarka_adi");
                ViewBag.KullaniciIsim = new SelectList(zb.kullanici.ToList(), "kullanici_id", "kullanici_adi");
                zb.Entry(query12).State = EntityState.Modified;
                zb.SaveChanges();
               
              
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var zimmet = zb.zimmet.Find(id);
                zb.zimmet.Remove(zimmet);
                zb.SaveChanges();
                return RedirectToAction("Index");



            }
            catch
            {
                return View();
            }
        }
    }
}