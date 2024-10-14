using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class About_adController : Controller
    {
        DbMyPortfolioNightEntities db=new DbMyPortfolioNightEntities();
        // GET: About_ad
        [HttpGet]
        public ActionResult Index()
        {
            var values = db.About.Find(1);
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(About a)
        {
            var yeni= db.About.Find(a.AboutId);
            yeni.Title = a.Title;
            yeni.Description = a.Description;
            yeni.ImageUrl = a.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}