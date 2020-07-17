using PetHelper.Data;
using PetHelper.Models.AppointmentModels;
using PetHelper.Models.PetModels;
using PetHelperMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Services
{
    public class AppointmentService
    {
        private readonly string _userId;
        private readonly ApplicationDbContext _dbContext;
        public AppointmentService(string userId)
        {
            _dbContext = new ApplicationDbContext();
            _userId = userId;
        }

        public bool CreateAppointment(AppointmentCreate model)
        {
            var entity = new Appointment
            {
                DateTime = model.DateTime,
                PetId = model.PetId,

                ServiceProviderId = model.ServiceProviderId,
                ServiceType = model.ServiceType
            };
            _dbContext.Appointments.Add(entity);
            return _dbContext.SaveChanges() == 1;
        }

        public List<AppointmentListDetail> GetAppointmentsByUserId()
        {
            var entity = _dbContext.Appointments.Where(e => e.Pet.PetOwnerId == _userId);
            return entity.Select(a => new AppointmentListDetail
            {
                Pet = a.Pet,
                ServiceProvider = a.ServiceProvider,
                DateTime = a.DateTime,
                ServiceType = a.ServiceType,
                AppointmentId = a.AppointmentId
            }).ToList();
        }

        public AppointmentListDetail GetAppointmentById(int id)
        {
            Appointment entity = (Appointment)_dbContext.Appointments.Where(e => e.Pet.PetOwnerId == _userId && e.AppointmentId == id);
            return new AppointmentListDetail
            {
                Pet = entity.Pet,
                ServiceProvider = entity.ServiceProvider,
                DateTime = entity.DateTime,
                ServiceType = entity.ServiceType,
                AppointmentId = entity.AppointmentId
            };
        }

        public List<PetListDetail> GetPetListByOwnerId()
        {
            var entity = _dbContext.Pets.Where(e => e.PetOwnerId == _userId);
            return entity.Select(a => new PetListDetail
            {
                Name = a.Name,
                PetId = a.PetId,
                PetType = a.PetType,
                PetOwner = a.PetOwner
            }).ToList();
        }

        public List<ServiceProvider> GetServiceProviders()
        {
            return _dbContext.ServiceProviders.ToList();
        }
        public bool UpdateAppointment(AppointmentEdit model)
        {
            var entity = _dbContext.Appointments.Single(e => e.AppointmentId == model.AppoinmentId && e.Pet.PetOwnerId == _userId);

            entity.Pet = model.Pet;
            entity.DateTime = model.DateTime;
            entity.ServiceProviderId = model.ServiceProviderId;
            entity.ServiceType = model.ServiceType;

            return _dbContext.SaveChanges() == 1;
        }

        public bool DeleteAppointmentByAppointmentId(int appointmentId)
        {
            _dbContext.Appointments.Remove(_dbContext.Appointments.Single(e => e.AppointmentId == appointmentId && e.Pet.PetOwnerId == _userId));

            return _dbContext.SaveChanges() == 1;
        }
    }
}