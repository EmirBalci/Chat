using Chat.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.UI.Controllers
{
    public class UserController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users loginUser)
        {
            var user = db.Users.FirstOrDefault(x=>x.Username == loginUser.Username);

            if (user == null)
            {
                ViewBag.Error = "Böyle bir kullanıcı yok lütfen kayıt ol.";
            }
            else if (user.Password != loginUser.Password)
            {
                ViewBag.Error = "Şifre yanlış.";
            }
            else
            {
                return RedirectToAction("Chat");
            }

            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users user)
        {
            var username = db.Users.FirstOrDefault(x => x.Username == x.Username)?.Username;
            if (username == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = "Bu kullanıcı adı bulunmaktadır..";
            }
            return View();
        }
    }
}