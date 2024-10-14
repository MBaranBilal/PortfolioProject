using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class InternshipController : Controller
    {
        DbMyPortfolioNightEntities db=new DbMyPortfolioNightEntities();
        // GET: Internship
        public ActionResult InternshipList()
        {
            var values=db.Internship.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateInternship()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateInternship(Internship ınternship)
        {
            db.Internship.Add(ınternship);
            db.SaveChanges();
            return RedirectToAction("InternshipList");
        }

        public ActionResult DeleteInternship(int id) 
        {
            var values = db.Internship.Find(id);
            db.Internship.Remove(values);
            db.SaveChanges();
            return RedirectToAction("InternshipList");
        }

        [HttpGet]
        public ActionResult UpdateInternship(int id) 
        {
            var values= db.Internship.Find(id); 
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateInternship(Internship ınternship) 
        {
            var values=db.Internship.Find(ınternship.InternshipID);
            values.Title=ınternship.Title;
            values.Description=ınternship.Description;
            db.SaveChanges();
            return RedirectToAction("InternshipList");
        }
    }
}