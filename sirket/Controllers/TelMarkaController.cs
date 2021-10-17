using sirket.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sirket.Controllers
{
    public class TelMarkaController : Controller
    {
        // GET: TelMarka
        SirketZT tm = new SirketZT();
        public ActionResult Index()
        {
            var degerler = tm.tel_marka.ToList();
            return View(degerler);
        }

        //Get
        public ActionResult TelMarkaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TelMarkaEkle(tel_marka t1)
        {
            try
            {
                // TODO: Add insert logic here
                tm.tel_marka.Add(t1);
                tm.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var query15 = tm.tel_marka.Where(t => t.telmarka_id == id).FirstOrDefault();
            return View(query15);
        }
        [HttpPost]
        public ActionResult Edit(tel_marka t1)
        {
            try
            {
                // TODO: Add update logic here
                var query15 = tm.tel_marka.Where(t => t.telmarka_id == t1.telmarka_id).FirstOrDefault();
                query15.telmarka_adi = t1.telmarka_adi;
                tm.Entry(query15).State = EntityState.Modified;
                tm.SaveChanges();
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
                var tel_marka = tm.tel_marka.Find(id);
                tm.tel_marka.Remove(tel_marka);
                tm.SaveChanges();
                return RedirectToAction("Index");



            }
            catch
            {
                return View();
            }

        }
    }
}