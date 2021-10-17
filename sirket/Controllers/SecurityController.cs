using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using sirket.Models.Entity;

namespace sirket.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        // GET: Security
        SirketZT db = new SirketZT();
       public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(admin admin)
        {

            var adminInDb = db.admin.FirstOrDefault(x => x.admin_ad == admin.admin_ad && x.admin_sifre==admin.admin_sifre);
            if(adminInDb !=null)
            {
                FormsAuthentication.SetAuthCookie(admin.admin_ad, false);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz kullanici. Kullanici adi ya da şifre Hatalı.";
                return View();
            }
        }
        
        public ActionResult Logout()
        {
            //Sisteme tanıtılmıs olan kullanıcıyı kaldırdık SignOut ile.
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
            //RedirectToAction komutu ile kullanıcı çıkış işleminin ardından sayfayı tekrar Login ekranına yönlendirdik.
        }


    }
}