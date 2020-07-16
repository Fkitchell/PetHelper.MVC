using PetHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Models.PetModels
{
    public class PetCreate
    {
        public string Name { get; set; }

        public PetType PetType { get; set; }
        public PetOwner PetOwner { get; set; }
    }
}
