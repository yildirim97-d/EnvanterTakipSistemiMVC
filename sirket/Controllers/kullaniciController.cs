using sirket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sirket.Controllers
{
    public class kullaniciController : Controller
    {
        // GET: kullanici
        SirketZT kc = new SirketZT();
        public ActionResult Index()
        {
            var degerler = kc.kullanici.ToList();
            return View(degerler);
        }

        
       

        // GET: kullanici/Create
        public ActionResult KullaniciEkle()
        {
            
            return View();
        }

        // POST: kullanici/Create
        [HttpPost]
        public ActionResult KullaniciEkle(kullanici k1)
        {
            try
            {
                // TODO: Add insert logic here
                kc.kullanici.Add(k1);
                kc.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: kullanici/Edit/5
        public ActionResult Edit(int id)
        {
            var query2 = kc.kullanici.Where(k => k.kullanici_id == id).FirstOrDefault();
            return View(query2);

        }

        // POST: kullanici/Edit/5
        [HttpPost]
        public ActionResult Edit(kullanici k1)
        {
            try
            {
                // TODO: Add update logic here
                var query2 = kc.kullanici.Where(k => k.kullanici_id == k1.kullanici_id).FirstOrDefault();
                query2.kullanici_adi = k1.kullanici_adi;
                query2.kullanici_sifre = k1.kullanici_sifre;
                query2.kullanici_departman = k1.kullanici_departman;
                kc.Entry(query2).State = EntityState.Modified;
                kc.SaveChanges();
                return RedirectToAction("Index");
             
            }
            catch
            {
                return View();
            }
        }

        // GET: kullanici/Delete/5
       

        // POST: kullanici/Delete/5
  
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var kullanici = kc.kullanici.Find(id);
                kc.kullanici.Remove(kullanici);
                kc.SaveChanges();
                return RedirectToAction("Index");


               
            }
            catch
            {
                return View();
            }
        }
    }
}
