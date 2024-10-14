using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace PortfolioProject.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill

        DbMyPortfolioNightEntities context=new DbMyPortfolioNightEntities();

        public ActionResult SkillList(int sayfa=1)
        {
            var values=context.Skill.ToList().ToPagedList(sayfa,5);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(Skill skill) 
        {
            if (!ModelState.IsValid)
            {
                return View("CreateSkill");
            }
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id) 
        {
            var value=context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id) 
        {
            var value = context.Skill.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var value = context.Skill.Find(skill.SkillId);
            value.SkillName = skill.SkillName;
            value.Rate = skill.Rate;
            value.Icon = skill.Icon;
            value.Status = skill.Status;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult ChangeSkillStatusToTrue(int id)
        {
            var skill = context.Skill.Find(id);
            skill.Status = true;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        public ActionResult ChangeSkillStatusToFalse(int id)
        {
            var skill = context.Skill.Find(id);
            skill.Status = false;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}