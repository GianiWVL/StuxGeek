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
            return View();
        }

        [HttpPost]
        public ActionResult New(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }

    }
}