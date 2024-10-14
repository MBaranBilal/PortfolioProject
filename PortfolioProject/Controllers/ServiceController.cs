using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class ServiceController : Controller
    {
        DbMyPortfolioNightEntities db = new DbMyPortfolioNightEntities();
        // GET: Service
        public ActionResult ServiceList()
        {
            var values = db.Service.ToList();
            return View(values);
        }

        //Hizmet ekleme
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            db.Service.Add(service);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        //Hizmet silme
        public ActionResult DeleteService(int id)
        {
            var values=db.Service.Find(id);
            db.Service.Remove(values);
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

        //Hizmet güncelleme
        [HttpGet]
        public ActionResult UpdateService(int id) 
        {
            var values= db.Service.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var values = db.Service.Find(service.ServiceId);
            values.Title = service.Title;
            values.Description = service.Description;
            values.Icon = service.Icon;
            db.SaveChanges();
            return RedirectToAction("ServiceList");
        }

    }
}