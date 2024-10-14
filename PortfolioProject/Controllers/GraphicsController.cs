using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class GraphicsController : Controller
    {
        DbMyPortfolioNightEntities db=new DbMyPortfolioNightEntities();
        // GET: Graphics
        public ActionResult Index()
        {
            var values=db.Skill.ToList();
            return View(values);
        }
    }
}