using PetHelper.Data;
using PetHelper.Models.PetModels;
using PetHelperMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Services
{
    public class PetService
    {
        private readonly string _userId;
        private readonly ApplicationDbContext _dbContext;
        public PetService(string userId)
        {
            _dbContext = new ApplicationDbContext();
            _userId = userId;
        }

        public bool CreatePet(PetCreate model)
        {
            var entity = new Pet
            {
                Name = model.Name,
                PetOwnerId = _userId,
                PetType = model.PetType,
            };

            _dbContext.Pets.Add(entity);

            return _dbContext.SaveChanges() == 1;
        }

        public PetListDetail GetPetByPetId(int petId)
        {
            var entity = _dbContext.Pets.Find(petId);

            var temp = new PetListDetail
            {
                PetId = entity.PetId,
                Name = entity.Name,
                PetType = entity.PetType,
            };

            return temp;
        }

        public IEnumerable<PetListDetail> GetPetsByUserId()
        {
            var entity = _dbContext.Pets.Where(e => e.PetOwnerId == _userId).ToList();
            return entity.Select(a => new PetListDetail
            {
                PetId = a.PetId,
                Name = a.Name,
                PetType = a.PetType,
            });
        }

        public bool UpdatePet(PetEdit model)
        {
            var entity = _dbContext.Pets.Single(e => e.PetId == model.PetId && e.PetOwnerId == _userId);

            entity.Name = model.Name;
            entity.PetType = model.PetType;

            return _dbContext.SaveChanges() == 1;
        }

        public bool DeletePetById(int petId)
        {
            var entity = _dbContext.Pets.Single(e => e.PetId == petId && e.PetOwnerId == _userId);

            _dbContext.Pets.Remove(entity);

            return _dbContext.SaveChanges() == 1;
        }
    }
}
