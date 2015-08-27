using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StuxGeek.Models;

namespace StuxGeek.Controllers
{
    public class UserController : Controller
    {

        StuxGeekContext db = new StuxGeekContext();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel newUser)
        {
            if (ModelState.IsValid) { 

                User user = new User();
                user.Username = newUser.Username;
                user.Password = newUser.Password;
                user.Email = newUser.Email;
                user.TimeOfRegistration = DateTime.Now;

                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult Login()
        {
            return View();
        }*/

        public ActionResult LostPassword()
        {
            return View();
        }

    }
}