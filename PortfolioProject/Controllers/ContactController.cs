using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();
        // GET: Contact
        
        public PartialViewResult PartialContactSidebar()
        {
            return PartialView();
        }

        public PartialViewResult PartialContactDetail()
        {
            ViewBag.adress=context.Profile.Select(x=>x.Adress).FirstOrDefault();
            ViewBag.description=context.Profile.Select(x=>x.Description).FirstOrDefault();
            ViewBag.phone=context.Profile.Select(x=>x.Phone).FirstOrDefault();
            ViewBag.email=context.Profile.Select(x=>x.Email).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialLocation()
        {
            return PartialView();
        }

    }
}