using PetHelper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHelper.Models.PetModels
{
    public class PetListDetail
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public PetOwner PetOwner { get; set; }
    }
}
