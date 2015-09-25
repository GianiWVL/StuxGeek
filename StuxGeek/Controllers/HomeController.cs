using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StuxGeek.Models;

namespace StuxGeek.Controllers
{
    public class HomeController : Controller
    {
        StuxGeekContext db = new StuxGeekContext();

        public ActionResult Index()
        {
            List<Post> listOfPosts = new List<Post>();
            listOfPosts = db.Posts.ToList();
            //listOfPosts = db.Posts.Take(10).ToList();
            return View(listOfPosts);
        }
    }
}