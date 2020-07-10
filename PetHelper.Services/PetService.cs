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
        private readonly Guid _userId;
        private readonly ApplicationDbContext _dbContext;
        public PetService(Guid userId)
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
                Type = model.Type,
            };

            _dbContext.Pets.Add(entity);

            return _dbContext.SaveChanges() == 1;
        }

        public PetListDetail GetPetByPetId(int petId)
        {
            var entity = _dbContext.Pets.Where(e => e.PetId == petId && e.PetOwnerId == _userId);

            return (PetListDetail)entity.Select(a => new PetListDetail
            {
                Name = a.Name,
                Type = a.Type,
            });
        }

        public List<PetListDetail> GetPetsByUserId(Guid _userId)
        {
            var entity = _dbContext.Pets.Where(e => e.PetOwnerId == _userId).ToList();
            return (List<PetListDetail>)entity.Select(a=> new PetListDetail
            {
                Name = a.Name,
                Type = a.Type,
            });
        }

        public bool UpdatePet(PetEdit model)
        {
            var entity = _dbContext.Pets.Single(e => e.PetId == model.PetId && e.PetOwnerId == _userId);

            entity.Name = model.Name;
            entity.Type = model.Type;

            return _dbContext.SaveChanges() == 1;
        }

        public bool DeletePet(int petId)
        {
            var entity = _dbContext.Pets.Single(e => e.PetId == petId && e.PetOwnerId == _userId);

            _dbContext.Pets.Remove(entity);

            return _dbContext.SaveChanges() == 1;
        }
    }
}
