using sirket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sirket.Controllers
{
    public class MarkaKategoriController : Controller
    {
        SirketZT mk = new SirketZT();
        // GET: MarkaKategori
        public ActionResult Index()
        {
            var degerler = mk.marka_kategori.ToList();
            return View(degerler);
        }
        //get
        public ActionResult MarkaKategoriEkle()
        {
            return View();
        }

        //post 
        [HttpPost]
        public ActionResult MarkaKategoriEkle(marka_kategori mk1)
        {
            try
            {
                // TODO: Add insert logic here
                mk.marka_kategori.Add(mk1);
                mk.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Edit(int id)
        {
            var query8 = mk.marka_kategori.Where(z => z.marka_id == id).FirstOrDefault();
            return View(query8);
        }
        [HttpPost]
        public ActionResult Edit(marka_kategori mk1)
        {

            try
            {
                // TODO: Add update logic here
                var query8 = mk.marka_kategori.Where(z => z.marka_id == mk1.marka_id).FirstOrDefault();
                query8.marka_ad = mk1.marka_ad;
                mk.Entry(query8).State = EntityState.Modified;
                mk.SaveChanges();
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
                var marka_kategori = mk.marka_kategori.Find(id);
                mk.marka_kategori.Remove(marka_kategori);
                mk.SaveChanges();
                return RedirectToAction("Index");



            }
            catch
            {
                return View();
            }
        }
    }
}