using BBallCamp.Models.CampModels;
using BBallCamp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BBallCamp.WebMVC.Controllers
{
    public class CampController : Controller
    {
        // GET: Camp
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CampServices(userId);
            var model = service.GetCampsByUserID(userId);

            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(CampCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRaterService();
            if (service.CreateCamp(model))
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Camp could not be added");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateRaterService();
            var model = service.GetCampByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRaterService();
            var detail = service.GetCampByID(id);
            var model = new CampEdit
            {
                CampID = detail.CampID,
                CampName = detail.CampName,
                CampCity = detail.CampCity,
                CampState = detail.CampState

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, CampEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.CampID != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreateRaterService();

            if (service.EditCamp(model))
            {
                TempData["SaveResult"] = "Your camp was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your camp could not be updated");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateRaterService();
            var model = service.GetCampByID(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteCamp(int id)
        {
            var service = CreateRaterService();

            service.DeleteCamp(id);

            TempData["SaveResult"] = "Your camp was deleted";
            return RedirectToAction("Index");
        }
        private CampServices CreateRaterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CampServices(userId);
            return service;
        }
    }
}