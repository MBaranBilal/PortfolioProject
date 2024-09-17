using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult CategoryList()
        {
            return View();
        }

        public ActionResult CreateCategory()
        {
            return View();
        }
    }
}