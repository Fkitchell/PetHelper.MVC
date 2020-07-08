using PetHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Models.PetModels
{
    public class PetEdit
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public PetOwner PetOwner { get; set; }
    }
}
