using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();

        // GET: Message
        public ActionResult Inbox()
        {
            var values=context.Contact.ToList();
            return View(values);
        }

        public ActionResult ChangeMessageStatusToTrue(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult ChangeMessageStatusToFalse(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult ViewMessage(int id)
        {
            ViewBag.message=context.Contact.Where(x=>x.ContactID==id).Select(x=>x.Message).FirstOrDefault();
            ViewBag.mail = context.Contact.Where(x => x.ContactID == id).Select(x => x.Email).FirstOrDefault();
            ViewBag.subject = context.Contact.Where(x => x.ContactID == id).Select(x => x.Subject).FirstOrDefault();
            return View();
        }

        public ActionResult DeleteMessage(int id)
        {
            var value=context.Contact.Find(id);
            context.Contact.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
    }
}