using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHelper.Data
{
    public class PetOwner : Person
    {
        public virtual ICollection<Pet> Pets{ get; set; }
    }
}