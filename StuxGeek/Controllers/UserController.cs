using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StuxGeek.Models;
using System.Web.Security;

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

            if (db.Users.FirstOrDefault(x => x.Email.ToLower() == newUser.Email.ToLower()) != null)
            {
                ModelState.AddModelError("Email", "Email address already exists. Please enter a different email address.");
            }

            if (db.Users.FirstOrDefault(x => x.Username == newUser.Username) != null)
            {
                ModelState.AddModelError("Username", "Username address already exists. Please enter a different Username");
            }

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

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {

            if (db.Users.FirstOrDefault(x => x.Email.ToLower() == login.Email.ToLower() && x.Password == login.Password) != null)
            {
                if (ModelState.IsValid)
                {
                    User user = db.Users.FirstOrDefault(x => x.Email.ToLower() == login.Email.ToLower() && x.Password == login.Password);
                    //FormsAuthentication.SetAuthCookie(user.Username, false);
                    
                    FormsAuthentication.GetAuthCookie(user.Username, false);

                    return RedirectToAction("Index", "Home");
                }
            }
            else 
            {
                ModelState.AddModelError("User", "Invalid Credentials");
            }

            return View();
        }

        public ActionResult LostPassword()
        {
            return View();
        }

    }
}