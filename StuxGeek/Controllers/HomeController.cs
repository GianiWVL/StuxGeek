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
            return View(db.Posts.ToList());
        }
    }
}