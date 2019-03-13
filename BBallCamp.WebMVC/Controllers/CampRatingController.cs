using BBallCamp.Models.CampRatingModels;
using BBallCamp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBallCamp.WebMVC.Controllers
{
    public class CampRatingController : Controller
    {
       
        public ActionResult Index()
        {
            var service = new CampRatingServices();
            var model = service.GetRatings();

            return View(model);

        }
        public ActionResult MyRatings()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = CreateRaterService();
            var model = service.GetRatingsByUserID(userId);

            return View(model);
        }
     
        public ActionResult Create()
        {
            var campId = Guid.Parse(User.Identity.GetUserId());
            var campService = new CampServices(campId);
            var campList = campService.GetCampsByUserID(campId);

            var raterId = Guid.Parse(User.Identity.GetUserId());
            var raterService = new RaterServices(raterId);
            var raterList = raterService.GetRatersByUserID(raterId);


            ViewBag.CampID = new SelectList(campList, "CampID", "CampName");
            ViewBag.RaterID = new SelectList(raterList, "RaterID", "DisplayInfo");


            return View();
        }
        
        [HttpPost]
        public ActionResult Create(CampRatingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var service = CreateRaterService();

            if (service.CreateRating(model))
            {
                return RedirectToAction("Index");
            }

            var campId = Guid.Parse(User.Identity.GetUserId());
            var campService = new CampServices(campId);
            var campList = campService.GetCampsByUserID(campId);

            var raterId = Guid.Parse(User.Identity.GetUserId());
            var raterService = new RaterServices(raterId);
            var raterList = raterService.GetRatersByUserID(raterId);


            ViewBag.CampID = new SelectList(campList, "CampID", "CampName");
            ViewBag.RaterID = new SelectList(raterList, "RaterID", "DisplayInfo");


            return View(model);
        }
        
        public ActionResult Details(int id)
        {
            var service = new CampRatingServices();
            var model = service.GetRatingsByRatingID(id);

            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var service = CreateRaterService();
            var detail = service.GetRatingsByRatingID(id);
            var model = new CampRatingEdit
            {
                RatingID = detail.RatingID,
                OverallRating = detail.OverallRating,
                ActivityRating = detail.ActivityRating,
                CoachingRating = detail.CoachingRating,
            };

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, CampRatingEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.RatingID != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreateRaterService();

            if (service.EditCampRating(model))
            {
                TempData["SaveResult"] = "Your rating was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your rating could not be updated");
            return View(model);

        }
        
        public ActionResult Delete(int id)
        {
            var service = CreateRaterService();
            var model = service.GetRatingsByRatingID(id);
            return View(model);
        }
       
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteRating(int id)
        {
            var service = CreateRaterService();
            service.DeleteRating(id);

            TempData["SaveResult"] = "Your rating was deleted";
            return RedirectToAction("Index");
        }

        private CampRatingServices CreateRaterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CampRatingServices(userId);
            return service;
        }
    }
}