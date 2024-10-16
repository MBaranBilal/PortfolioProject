﻿using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();

        public ActionResult SocialMediaList()
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id) 
        {
            var value=context.SocialMedia.Find(id);
            context.SocialMedia.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value = context.SocialMedia.Find(socialMedia.SocialMediaId);
            value.Title = socialMedia.Title;
            value.Url = socialMedia.Url;
            value.Icon = socialMedia.Icon;
            value.Status = socialMedia.Status;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult ChangeSocialMediaStatusToTrue(int id)
        {
            var socialMedia = context.SocialMedia.Find(id);
            socialMedia.Status = true;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult ChangeSocialMediaStatusToFalse(int id)
        {
            var socialMedia = context.SocialMedia.Find(id);
            socialMedia.Status = false;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}