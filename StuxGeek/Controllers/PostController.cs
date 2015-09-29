using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StuxGeek.Models;

namespace StuxGeek.Controllers
{
    public class PostController : Controller
    {

        StuxGeekContext db = new StuxGeekContext();

        [HttpGet]
        public ActionResult New()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult New(Post post)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                post.PostDate = DateTime.Now;
                post.Author = User.Identity.Name;

                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Manage()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        [Route("post/read/{postTitle}")]
        public ActionResult Read(string postTitle)
        {
            Post post = db.Posts.FirstOrDefault(x => x.Title.Equals(postTitle.Replace("-"," ")));
            if (post != null)
            {
                return View(post);
            }
            else {
                return RedirectToAction("index", "home");
            }
            
        }

    }
}