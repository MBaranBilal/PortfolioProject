using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ReferanceController : Controller
    {
        // GET: Referance
        DbMyPortfolioNightEntities db=new DbMyPortfolioNightEntities();
        public ActionResult ReferanceList()
        {
            var values=db.Testimonial.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateReferance() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateReferance(Testimonial referance)
        {
            db.Testimonial.Add(referance);
            db.SaveChanges();
            return RedirectToAction("ReferanceList");
        }

        public ActionResult DeleteReferance(int id) 
        {
            var values=db.Testimonial.Find(id);
            db.Testimonial.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ReferanceList");
        }

        [HttpGet]
        public ActionResult UpdateReferance(int id)
        {
            var values = db.Testimonial.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateReferance(Testimonial referance)
        {
            var values = db.Testimonial.Find(referance.TestimonialID);
            values.NameSurname=referance.NameSurname;
            values.Comment=referance.Comment;
            values.Star=referance.Star;
            db.SaveChanges();
            return RedirectToAction("ReferanceList");
        }
    }
}