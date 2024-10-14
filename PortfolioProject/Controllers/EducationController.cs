using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class EducationController : Controller
    {
        DbMyPortfolioNightEntities db=new DbMyPortfolioNightEntities();
        // GET: Default
        //Eğitim bilgilerini listeleme
        public ActionResult EducationList()
        {
            var values=db.Education.ToList();
            return View(values);
        }

        //Eğitim bilgilerini güncelleme için httpget ve httppost etiketleri altında çalışma yapmamız gerekir.Birisi sayfayı görüntülerken(httpget) diğeri sayafaya veri girişi olduğunda(httppost) çalışacak.
        [HttpGet]
        public ActionResult CreateEducation()
        {
           return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Education education)
        {          
            db.Education.Add(education);
            db.SaveChanges();
            return RedirectToAction("EducationList");
        }

        //Eğitim silme
        public ActionResult DeleteEducation(int id)
        {
            var values = db.Education.Find(id);
            db.Education.Remove(values);
            db.SaveChanges();
            return RedirectToAction("EducationList");
        }

        //Eğitim Güncellemede de eğitim eklemedeki gibi çalışmamız gerekiyor. yani hem httpget hem de httppost altında iki ayrı foknsiyonla method overloading yapacağız.
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var values=db.Education.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var values = db.Education.Find(education.EducationId);
            values.Title = education.Title;
            values.SubTitle = education.SubTitle;
            values.Description = education.Description;
            db.SaveChanges();
            return RedirectToAction("EducationList");
        }
    }
}