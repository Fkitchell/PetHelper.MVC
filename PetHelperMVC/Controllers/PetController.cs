using Microsoft.AspNet.Identity;
using PetHelper.Models.PetModels;
using PetHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHelperMVC.Controllers
{
    //[Authorize(Roles = "PetOwner")]
    public class PetController : Controller
    {
        private PetService CreatePetService()
        {
            var userId = User.Identity.GetUserId();
            return new PetService(userId);
        }

        // GET: Pet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var service = CreatePetService();
            if (service.CreatePet(model))
            {
                TempData["SaveResult"] = "Your pet was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Pet could not be created.");
            return View(model);
        }

        // GET: Pet/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int petId)
        {
            var service = CreatePetService();
            var model = service.GetPetByPetId(petId);
            return View(model);
        }

        // POST: Pet/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePet(int petId)
        {
            var service = CreatePetService();
            service.DeletePetById(petId);
            TempData["SaveResult"] = "Your pet was deleted.";
            return RedirectToAction("Index");
        }

        // GET: Pet/Details/5
        public ActionResult Details(int petId)
        {
            var service = CreatePetService();
            var model = service.GetPetByPetId(petId);
            return View(model);
        }


        // GET: Pet/Edit/5
        public ActionResult Edit(int petId)
        {
            var service = CreatePetService();
            var model = service.GetPetByPetId(petId);

            return View(model);
        }

        // POST: Pet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int petId, PetEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PetId != petId)
            {
                ModelState.AddModelError("", "ID mismatch.");
                return View(model);
            }

            var service = CreatePetService();
            if (service.UpdatePet(model))
            {
                TempData["SaveResult"] = "Your pet was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Pet could not be updated.");
            return View(model);
        }

        // GET: Pet
        public ActionResult Index()
        {
            var service = CreatePetService();
            var model = service.GetPetsByUserId();
            return View(model);
        }
    }
}