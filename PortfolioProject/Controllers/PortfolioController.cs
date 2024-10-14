using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        DbMyPortfolioNightEntities db = new DbMyPortfolioNightEntities();
        public ActionResult PortfolioList()
        {
            var values=db.Portfolio.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreatePortfolio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePortfolio(Portfolio portfolio)
        {
            db.Portfolio.Add(portfolio);
            db.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        public ActionResult DeletePortfolio(int id) 
        {
            var values = db.Portfolio.Find(id);
            db.Portfolio.Remove(values);
            db.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public ActionResult UpdatePortfolio(int id) 
        {
            var values=db.Portfolio.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdatePortfolio(Portfolio portfolio)
        {
            var values = db.Portfolio.Find(portfolio.FeatureId);
            values.Title = portfolio.Title;
            values.SubTitle = portfolio.SubTitle;
            values.Image = portfolio.Image;
            db.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}