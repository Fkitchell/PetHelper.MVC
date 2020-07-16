using Microsoft.AspNet.Identity;
using PetHelper.Models.AppointmentModels;
using PetHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHelperMVC.Controllers
{
    [Authorize(Roles = "PetOwner")]
    public class AppointmentController : Controller
    {
        private AppointmentService CreateAppointmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            return new AppointmentService(userId);
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAppointmentService();

            if (service.CreateAppointment(model))
            {
                TempData["SaveResult"] = "Appointment created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Appointment could not be created.");
            return View(model);
        }

        // GET: Appointment/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int appointmentId)
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointmentById(appointmentId);
            return View(model);
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteAppointment(int appointmentId)
        {
            var service = CreateAppointmentService();
            service.DeleteAppointmentByAppointmentId(appointmentId);
            TempData["SaveResult"] = "Appointment deleted successfully.";
            return RedirectToAction("Index");
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int appointmentId)
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointmentById(appointmentId);
            return View(model);
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int appointmentId)
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointmentById(appointmentId);
            return View(model);
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int appointmentId, AppointmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AppoinmentId != appointmentId)
            {
                ModelState.AddModelError("", "ID mismatch.");
                return View(model);
            }

            var service = CreateAppointmentService();
            if (service.UpdateAppointment(model))
            {
                TempData["SaveResult"] = "Your appointment was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your appointment could not be updated.");
            return View(model);
        }

        // GET: Appointment
        public ActionResult Index()
        {
            var service = CreateAppointmentService();
            var model = service.GetAppointmentsByUserId();
            return View(model);
        }
    }
}

