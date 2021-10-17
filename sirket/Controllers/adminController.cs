using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using sirket.Models.Entity;

namespace sirket.Controllers
{
    public class adminController : Controller
    {
        SirketZT ad = new SirketZT();
        // GET: admin
        public ActionResult Index()
        {
            var degerler = ad.admin.ToList();

            return View(degerler);
        }

        [HttpGet]
       public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(admin s1)
        {
           

            ad.admin.Add(s1);

            ad.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SİL(int id)
        {
            var admin = ad.admin.Find(id);
            ad.admin.Remove(admin);
            ad.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var query = ad.admin.Where(a => a.admin_id == id).FirstOrDefault();
            return View(query);
        }

        [HttpPost]
        public ActionResult Guncelle(admin s1)
        {
           
            var query = ad.admin.Where(a => a.admin_id == s1.admin_id).FirstOrDefault();
            query.admin_ad = s1.admin_ad;
            query.admin_sifre = s1.admin_sifre;
            ad.Entry(query).State = EntityState.Modified;
            ad.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}