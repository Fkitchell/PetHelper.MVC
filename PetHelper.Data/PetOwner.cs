using PetHelperMVC.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHelper.Data
{
    public class PetOwner : ApplicationUser
    {
        public virtual ICollection<Pet> Pets{ get; set; }
    }
}